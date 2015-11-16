namespace YekanPedia.RoboTele.Domain.Responses.Methods
{
    using Json;
    using Bases;
    public class SetWebhookResponse : BaseMethodResponse
    {
        public static SetWebhookResponse Parse(JsonData data)
        {
            if (data == null)
            {
                return null;
            }

            return new SetWebhookResponse
            {
                Ok = data.Get<bool>("ok"),
                ErrorCode = data.Get<int?>("error_code"),
                Description = data.Get<string>("description")
            };
        }
    }
}