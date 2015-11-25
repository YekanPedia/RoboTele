namespace YekanPedia.RoboTele.Domain.Responses.Types
{
    using Json;
    public class UpdateResponse
    {
        public int UpdateId { get; private set; }
        public MessageResponse Message { get; private set; }

        public static UpdateResponse Parse(JsonData data)
        {
            if (data == null || !data.Has("update_id"))
            {
                return null;
            }

            return new UpdateResponse
            {
                UpdateId = data.Get<int>("update_id"),
                Message = MessageResponse.Parse(data.GetJson("message"))
            };
        }
    }
}