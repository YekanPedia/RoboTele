namespace YekanPedia.RoboTele.Domain.Http
{
    public class HttpData
    {
        public HttpData()
        {
            Parameters = new HttpParameterList();
            Files = new HttpFileList();
        }

        public HttpParameterList Parameters { get; set; }
        public HttpFileList Files { get; set; }
    }
}