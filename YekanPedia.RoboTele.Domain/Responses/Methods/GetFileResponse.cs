namespace YekanPedia.RoboTele.Domain.Responses.Methods
{
    using Json;
    using Bases;
    using Types;
    public class GetFileResponse : BaseMethodResponse
    {
        public FileResponse Result { get; private set; }

        public static GetFileResponse Parse(JsonData data)
        {
            if (data == null)
            {
                return null;
            }

            return new GetFileResponse
            {
                Ok = data.Get<bool>("ok"),
                ErrorCode = data.Get<int?>("error_code"),
                Description = data.Get<string>("description"),
                Result = FileResponse.Parse(data.GetJson("result"))
            };
        }
    }
}
