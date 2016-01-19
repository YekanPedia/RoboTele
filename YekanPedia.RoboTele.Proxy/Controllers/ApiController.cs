namespace YekanPedia.RoboTele.Proxy.Controllers
{
    using System.Web.Mvc;
    using Domain;
    using Domain.Requests.Methods;
    using System;
    using Domain.Responses.Types;
    using Service.Interfaces;
    using System.Text.RegularExpressions;
    using Resources;

    public class ApiController : Controller
    {
        readonly IUserService _userSercvice;
        public ApiController(IUserService userService)
        {
            _userSercvice = userService;
        }
        const int UpdateTimeoutInSeconds = 30;
        static Robot _bot;
        static Robot Bot => _bot ?? (_bot = new Robot(AppSettings.ApiKey));
        static int lastUpdateId = 0;

        [HttpGet]
        public JsonResult GetUpdates()
        {
            try
            {
                var updates = Bot.GetUpdates(new GetUpdatesRequest
                {
                    Offset = lastUpdateId + 1,
                    Timeout = UpdateTimeoutInSeconds
                });
                foreach (var update in updates.Result)
                {
                    if (_userSercvice.IsTelegramAdded((int)update.Message?.Chat.Id))
                    {
                        lastUpdateId = update.UpdateId;
                        continue;
                    }
                    if (!string.IsNullOrEmpty(update?.Message?.Text) && update?.Message?.Text.ToLower().Trim() == "/start")
                    {
                        SendEmailRequest(update);
                    }
                    else
                    {
                        UpdateEmailAddress(update);
                    }
                    lastUpdateId = update.UpdateId;
                }
                return Json(updates.Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        void SendEmailRequest(UpdateResponse updateResponse)
        {
            if (string.IsNullOrEmpty(updateResponse?.Message?.Text))
                return;
            var senderUserName = updateResponse.Message.From.UserName;
            var chatId = updateResponse.Message?.Chat.Id;
            Bot.SendMessage(new SendMessageRequest
            {
                ChatId = (int)chatId,
                Text = string.Format(BusinessMessages.Start, senderUserName),
            });
        }

        void UpdateEmailAddress(UpdateResponse updateResponse)
        {
            if (string.IsNullOrEmpty(updateResponse?.Message?.Text))
                return;
            var senderUserName = updateResponse.Message.From.UserName;
            var chatId = updateResponse.Message?.Chat.Id;
            var Reg = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            if (!Reg.IsMatch(updateResponse?.Message?.Text))
            {
                Bot.SendMessage(new SendMessageRequest
                {
                    ChatId = (int)chatId,
                    Text = string.Format(BusinessMessages.IncorrectEmail, senderUserName) ,
                    ReplyToMessageId = updateResponse.Message.MessageId
                });
                return;
            }
            var result = _userSercvice.Update(updateResponse?.Message?.Text, (int)chatId);
            var returnText = string.Empty;

            switch (result)
            {
                case UpdateResult.UserNotExist:
                    {
                        returnText = BusinessMessages.UserNotExist;
                        break;
                    }
                case UpdateResult.Success:
                    {
                        returnText = string.Format(BusinessMessages.EmailSaved, senderUserName);
                        try
                        {
                            Bot.GetUserProfilePhotos(new GetUserProfilePhotosRequest { UserId = (int)chatId });
                        }
                        catch (Exception e)
                        {
                            Console.Write(e.Message);
                        }
                        break;
                    }
                case UpdateResult.Error:
                    {
                        returnText = string.Format(BusinessMessages.Error, senderUserName);
                        break;
                    }
            }
            Bot.SendMessage(new SendMessageRequest
            {
                ChatId = (int)chatId,
                Text = returnText,
                ReplyToMessageId = updateResponse.Message.MessageId
            });
        }
    }
}