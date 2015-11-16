namespace YekanPedia.RoboTele.Domain.Requests.Methods
{
    using Http;
    using Bases;
    public class GetUpdatesRequest : BaseMethodRequest
    {
        public int? Offset { get; set; }

        /// <summary>
        /// Limits the number of updates to be retrieved. Values between 1—100 are accepted. Defaults to 100
        /// </summary>
        public int? Limit { get; set; }
        public int? Timeout { get; set; }

        public override string MethodName => "getUpdates";

        public override HttpData Parse()
        {
            return new HttpData
            {
                Parameters = new HttpParameterList
                {
                    { "offset", Offset },
                    { "limit", Limit },
                    { "timeout", Timeout }
                }
            };
        }
    }
}