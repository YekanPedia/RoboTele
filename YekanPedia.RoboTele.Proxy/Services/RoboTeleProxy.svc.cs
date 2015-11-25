namespace YekanPedia.RoboTele.Proxy.Services
{
    using System;
    using Domain;
    using Model;
    using Domain.Requests.Methods;
    using System.Collections.Generic;

    public class RoboTeleProxy : IRoboTeleProxy
    {
        const int UpdateTimeoutInSeconds = 30;
        static Robot _bot;
        static Robot Bot => _bot ?? (_bot = new Robot(AppSettings.ApiKey));

        public void SendMessage(List<SendMessageModel> model, SecurityModel security)
        {
            try
            {
                if (security.UserName == AppSettings.UserName && security.Password == AppSettings.Password)
                    foreach (var item in model)
                    {
                        Bot.SendMessage(new SendMessageRequest
                        {
                            ChatId = item.ChatId,
                            Text = item.Message
                        });
                    }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }
    }
}
