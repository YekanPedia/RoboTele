namespace YekanPedia.RoboTele.Domain.Requests.Methods
{
    using Http;
    using Bases;
    using Types;
    public class SendVoiceRequest : BaseMethodRequest
    {
        public int ChatId { get; set; }
        public InputFileRequest Voice { get; set; }
        public int? Duration { get; set; }
        public int? ReplyToMessageId { get; set; }
        public ReplyMarkupRequest ReplyMarkup { get; set; }

        public override string MethodName => "sendVoice";

        public override HttpData Parse()
        {
            var httpData = new HttpData
            {
                Parameters = new HttpParameterList
                {
                    { "chat_id", ChatId },
                    { "duration", Duration },
                    { "reply_to_message_id", ReplyToMessageId }
                }
            };

            Voice?.Parse(httpData, "voice");
            ReplyMarkup?.Parse(httpData, "reply_markup");

            return httpData;
        }
    }
}