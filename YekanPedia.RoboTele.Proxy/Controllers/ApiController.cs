namespace YekanPedia.RoboTele.Proxy.Controllers
{
    using System.Web.Mvc;
    using Domain;
    using Domain.Requests.Methods;
    using System;
    using Domain.Responses.Types;
    using Service.Interfaces;
    using System.Text.RegularExpressions;

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
                Text = $"Hi {senderUserName} , My name is YekanPediaBot, Please send me your email address to join together !",
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
                    Text = $"Sorry {senderUserName} !, Your Email is not correct, Please Send Again!",
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
                        returnText = $"Sorry {senderUserName} , your email address not registered in yekanpedia.org yet. please register in http://cms.yekanpedia.org and try again !";
                        break;
                    }
                case UpdateResult.Success:
                    {
                        returnText = $"Thanks {senderUserName} , Your Email Address Have Been Added.";
                        break;
                    }
                case UpdateResult.Error:
                    {
                        returnText = $"Sorry {senderUserName} , the process of save was considered error. please send again !";
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