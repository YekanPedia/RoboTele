namespace YekanPedia.RoboTele.Domain.Http
{
    public class HttpFile
    {
        public string Key { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] File { get; set; }
    }
}