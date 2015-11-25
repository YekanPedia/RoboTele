namespace YekanPedia.RoboTele.Domain.Requests.Types.Bases
{
    using Http;
    public abstract class BaseTypeRequest
    {
        public abstract void Parse(HttpData httpData, string key);
    }
}