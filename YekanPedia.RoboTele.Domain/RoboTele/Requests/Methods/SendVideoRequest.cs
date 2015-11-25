namespace YekanPedia.RoboTele.Domain.Requests.Methods
{
    using Http;
    using Bases;
    using Types;
    public class SendVideoRequest : BaseMethodRequest
    {
        public int ChatId { get; set; }
        public InputFileRequest Video { get; set; }
        public int? Duration { get; set; }
        public string Caption { get; set; }
        public int ReplyToMessageId { get; set; }
        public ReplyMarkupRequest ReplyMarkup { get; set; }

        public override string MethodName => "sendVideo";

        public override HttpData Parse()
        {
            var httpData = new HttpData
            {
                Parameters = new HttpParameterList
                {
                    { "chat_id", ChatId },
                    { "duration", Duration },
                    { "caption", Caption },
                    { "reply_to_message_id", ReplyToMessageId }
                }
            };

            Video?.Parse(httpData, "video");
            ReplyMarkup?.Parse(httpData, "reply_markup");

            return httpData;
        }
    }
}