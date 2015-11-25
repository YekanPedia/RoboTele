﻿namespace YekanPedia.RoboTele.Domain.Requests.Methods
{
    using Http;
    using Bases;
    using Types;
    public class SendMessageRequest : BaseMethodRequest
    {
        public int ChatId { get; set; }
        public string Text { get; set; }
        public ParseMode ParseMode { get; set; }
        public bool DisableWebPagePreview { get; set; }
        public int? ReplyToMessageId { get; set; }
        public ReplyMarkupRequest ReplyMarkup { get; set; }

        public override string MethodName => "sendMessage";

        public override HttpData Parse()
        {
            var httpData = new HttpData
            {
                Parameters = new HttpParameterList
                {
                    { "chat_id", ChatId },
                    { "text", Text },
                    { "disable_web_page_preview", DisableWebPagePreview },
                    { "reply_to_message_id", ReplyToMessageId }
                }
            };
            string parseMode = null;
            switch (ParseMode)
            {
                case ParseMode.Markdown:
                    parseMode = "Markdown";
                    break;
            }
            httpData.Parameters.Add("parse_mode", parseMode);
            ReplyMarkup?.Parse(httpData, "reply_markup");
            return httpData;
        }
    }
}