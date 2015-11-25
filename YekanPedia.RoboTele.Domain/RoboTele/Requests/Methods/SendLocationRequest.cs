namespace YekanPedia.RoboTele.Domain.Requests.Methods
{
    using Http;
    using Bases;
    using Types;
    public class SendLocationRequest : BaseMethodRequest
    {
        public int ChatId { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int ReplyToMessageId { get; set; }
        public ReplyMarkupRequest ReplyMarkup { get; set; }

        public override string MethodName => "sendLocation";

        public override HttpData Parse()
        {
            var httpData = new HttpData
            {
                Parameters = new HttpParameterList
                {
                    { "chat_id", ChatId },
                    { "latitude", Latitude },
                    { "longitude", Longitude },
                    { "reply_to_message_id", ReplyToMessageId }
                }
            };

            ReplyMarkup?.Parse(httpData, "reply_markup");

            return httpData;
        }
    }
}