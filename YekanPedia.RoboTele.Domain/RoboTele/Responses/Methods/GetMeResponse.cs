namespace YekanPedia.RoboTele.Domain.Responses.Methods
{
    using Json;
    using Bases;
    using Types;
    public class GetMeResponse : BaseMethodResponse
    {
        public UserResponse Result { get; private set; }

        public static GetMeResponse Parse(JsonData data)
        {
            if (data == null)
            {
                return null;
            }

            return new GetMeResponse
            {
                Ok = data.Get<bool>("ok"),
                ErrorCode = data.Get<int?>("error_code"),
                Description = data.Get<string>("description"),
                Result = UserResponse.Parse(data.GetJson("result"))
            };
        }
    }
}