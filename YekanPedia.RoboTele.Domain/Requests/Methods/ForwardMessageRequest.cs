namespace YekanPedia.RoboTele.Domain.Requests.Methods
{
    using Http;
    using Bases;
    public class ForwardMessageRequest : BaseMethodRequest
    {
        public int ChatId { get; set; }
        public int FromChatId { get; set; }
        public int MessageId { get; set; }

        public override string MethodName => "forwardMessage";

        public override HttpData Parse()
        {
            return new HttpData
            {
                Parameters = new HttpParameterList
                {
                    { "chat_id", ChatId },
                    { "from_chat_id", FromChatId },
                    { "message_id", MessageId }
                }
            };
        }
    }
}