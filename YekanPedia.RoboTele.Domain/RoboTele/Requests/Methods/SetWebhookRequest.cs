namespace YekanPedia.RoboTele.Domain.Requests.Methods
{
    using Http;
    using Bases;
    using Types;
    public class SetWebhookRequest : BaseMethodRequest
    {
        public string Url { get; set; }
        public InputFileRequest Certificate { get; set; }

        public override string MethodName => "setWebhook";

        public override HttpData Parse()
        {
            var httpData = new HttpData
            {
                Parameters = new HttpParameterList
                {
                    { "url", Url }
                }
            };

            Certificate?.Parse(httpData, "certificate");

            return httpData;
        }
    }
}