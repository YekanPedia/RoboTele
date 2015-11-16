namespace YekanPedia.RoboTele.Domain.Requests.Methods
{
    using Http;
    using Bases;
    public class GetMeRequest : BaseMethodRequest
    {
        public override string MethodName => "getMe";

        public override HttpData Parse()
        {
            return new HttpData();
        }
    }
}