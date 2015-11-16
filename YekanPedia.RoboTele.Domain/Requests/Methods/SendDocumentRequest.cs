namespace YekanPedia.RoboTele.Domain.Requests.Methods
{
    using Http;
    using Bases;
    using Types;
    public class SendDocumentRequest : BaseMethodRequest
    {
        public int ChatId { get; set; }
        public InputFileRequest Document { get; set; }
        public int ReplyToMessageId { get; set; }
        public ReplyMarkupRequest ReplyMarkup { get; set; }

        public override string MethodName => "sendDocument";

        public override HttpData Parse()
        {
            var httpData = new HttpData
            {
                Parameters = new HttpParameterList
                {
                    { "chat_id", ChatId },
                    { "reply_to_message_id", ReplyToMessageId }
                }
            };

            Document?.Parse(httpData, "document");
            ReplyMarkup?.Parse(httpData, "reply_markup");

            return httpData;
        }
    }
}