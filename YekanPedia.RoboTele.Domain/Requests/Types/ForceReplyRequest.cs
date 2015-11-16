namespace YekanPedia.RoboTele.Domain.Requests.Types
{
    using Http;
    using Json;
    using Bases;
    public class ForceReplyRequest : BaseTypeRequest
    {
        public bool ForceReply => true;

        public bool Selective { get; set; }

        public override void Parse(HttpData httpData, string key)
        {
            httpData.Parameters.Add(key, JsonData.Serialize(new
            {
                force_reply = ForceReply,
                selective = Selective
            }));
        }
    }
}