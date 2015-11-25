namespace YekanPedia.RoboTele.Domain.Responses.Methods
{
    using Json;
    using Bases;
    public class SendChatActionResponse : BaseMethodResponse
    {
        public static SendChatActionResponse Parse(JsonData data)
        {
            if (data == null)
            {
                return null;
            }

            return new SendChatActionResponse
            {
                Ok = data.Get<bool>("ok"),
                ErrorCode = data.Get<int?>("error_code"),
                Description = data.Get<string>("description")
            };
        }
    }
}