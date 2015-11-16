namespace YekanPedia.RoboTele.Domain.Requests.Methods
{
    using Http;
    using Bases;
    using Types;
    public class SendPhotoRequest : BaseMethodRequest
    {
        public int ChatId { get; set; }
        public InputFileRequest Photo { get; set; }
        public string Caption { get; set; }
        public int ReplyToMessageId { get; set; }
        public ReplyMarkupRequest ReplyMarkup { get; set; }

        public override string MethodName => "sendPhoto";

        public override HttpData Parse()
        {
            var httpData = new HttpData
            {
                Parameters = new HttpParameterList
                {
                    { "chat_id", ChatId },
                    { "caption", Caption },
                    { "reply_to_message_id", ReplyToMessageId }
                }
            };

            Photo?.Parse(httpData, "photo");
            ReplyMarkup?.Parse(httpData, "reply_markup");

            return httpData;
        }
    }
}