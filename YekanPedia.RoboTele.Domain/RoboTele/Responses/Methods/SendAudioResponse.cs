namespace YekanPedia.RoboTele.Domain.Responses.Methods
{
    using Json;
    using Bases;
    using Types;
    public class SendAudioResponse : BaseMethodResponse
    {
        public MessageResponse Result { get; private set; }

        public static SendAudioResponse Parse(JsonData data)
        {
            if (data == null)
            {
                return null;
            }

            return new SendAudioResponse
            {
                Ok = data.Get<bool>("ok"),
                ErrorCode = data.Get<int?>("error_code"),
                Description = data.Get<string>("description"),
                Result = MessageResponse.Parse(data.GetJson("result"))
            };
        }
    }
}