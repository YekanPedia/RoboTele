namespace YekanPedia.RoboTele.Domain.Requests.Methods
{
    using Http;
    using Bases;
    using Types;
    public class SendStickerRequest : BaseMethodRequest
    {
        public int ChatId { get; set; }
        public InputFileRequest Sticker { get; set; }
        public int ReplyToMessageId { get; set; }
        public ReplyMarkupRequest ReplyMarkup { get; set; }

        public override string MethodName => "sendSticker";

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

            Sticker?.Parse(httpData, "sticker");
            ReplyMarkup?.Parse(httpData, "reply_markup");

            return httpData;
        }
    }
}