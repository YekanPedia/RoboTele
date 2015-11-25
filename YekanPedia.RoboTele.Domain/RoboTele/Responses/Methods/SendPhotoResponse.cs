namespace YekanPedia.RoboTele.Domain.Responses.Methods
{
    using Json;
    using Bases;
    using Types;
    public class SendPhotoResponse : BaseMethodResponse
    {
        public MessageResponse Result { get; private set; }

        public static SendPhotoResponse Parse(JsonData data)
        {
            if (data == null)
            {
                return null;
            }

            return new SendPhotoResponse
            {
                Ok = data.Get<bool>("ok"),
                ErrorCode = data.Get<int?>("error_code"),
                Description = data.Get<string>("description"),
                Result = MessageResponse.Parse(data.GetJson("result"))
            };
        }
    }
}