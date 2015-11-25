namespace YekanPedia.RoboTele.Domain.Requests.Methods.Bases
{
    using Http;
    public abstract class BaseMethodRequest
    {
        public abstract string MethodName { get; }
        public abstract HttpData Parse();
    }
}