﻿namespace YekanPedia.RoboTele.Domain.Requests.Methods
{
    using Bases;
    using Http;
    using Types;
    public class SendAudioRequest : BaseMethodRequest
    {
        public int ChatId { get; set; }
        public InputFileRequest Audio { get; set; }
        public int? Duration { get; set; }
        public string Performer { get; set; }
        public string Title { get; set; }
        public int ReplyToMessageId { get; set; }
        public ReplyMarkupRequest ReplyMarkup { get; set; }

        public override string MethodName => "sendAudio";

        public override HttpData Parse()
        {
            var httpData = new HttpData
            {
                Parameters = new HttpParameterList
                {
                    { "chat_id", ChatId },
                    { "duration", Duration },
                    { "performer", Performer },
                    { "title", Title },
                    { "reply_to_message_id", ReplyToMessageId }
                }
            };

            Audio?.Parse(httpData, "audio");
            ReplyMarkup?.Parse(httpData, "reply_markup");

            return httpData;
        }
    }
}