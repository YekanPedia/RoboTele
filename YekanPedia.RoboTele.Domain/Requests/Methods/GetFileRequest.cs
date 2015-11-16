namespace YekanPedia.RoboTele.Domain.Requests.Methods
{
    using Http;
    using Bases;
    public class GetFileRequest : BaseMethodRequest
    {
        public string FileId { get; set; }

        public override string MethodName => "getFile";

        public override HttpData Parse()
        {
            return new HttpData
            {
                Parameters = new HttpParameterList
                {
                    { "file_id", FileId }
                }
            };
        }
    }
}
