namespace YekanPedia.RoboTele.Domain.Responses.Methods
{
    using Json;
    using Bases;
    using Types;
    public class GetUserProfilePhotosResponse : BaseMethodResponse
    {
        public UserProfilePhotosResponse Result { get; private set; }

        public static GetUserProfilePhotosResponse Parse(JsonData data)
        {
            if (data == null)
            {
                return null;
            }

            return new GetUserProfilePhotosResponse
            {
                Ok = data.Get<bool>("ok"),
                ErrorCode = data.Get<int?>("error_code"),
                Description = data.Get<string>("description"),
                Result = UserProfilePhotosResponse.Parse(data.GetJson("result"))
            };
        }
    }
}