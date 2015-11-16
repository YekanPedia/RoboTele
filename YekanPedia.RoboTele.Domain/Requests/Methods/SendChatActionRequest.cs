namespace YekanPedia.RoboTele.Domain.Requests.Methods
{
    using Http;
    using Bases;
    using Types;
    public class SendChatActionRequest : BaseMethodRequest
    {
        public int ChatId { get; set; }
        public ActionRequest Action { get; set; }

        public override string MethodName => "sendChatAction";

        public override HttpData Parse()
        {
            var httpData = new HttpData
            {
                Parameters = new HttpParameterList
                {
                    { "chat_id", ChatId }
                }
            };

            Action?.Parse(httpData, "action");

            return httpData;
        }
    }
}