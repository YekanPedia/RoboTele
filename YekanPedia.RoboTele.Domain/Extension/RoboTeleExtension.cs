namespace YekanPedia.RoboTele.Domain
{
    using System.Threading.Tasks;
    using Responses.Methods;
    using System.Net;

    public static class RoboTeleExtension
    {
        public static byte[] DownloadFile(this Robot bot, GetFileResponse getFileResponse)
        {
            if (string.IsNullOrEmpty(getFileResponse?.Result?.FilePath))
                return null;
            using (var client = new WebClient())
            {
                try
                {
                    return client.DownloadData($"{Robot.ApiUrl}/file/bot{bot.ApiToken}/{getFileResponse.Result.FilePath}");
                }
                catch
                {
                    return null;
                }
            }
        }

        public static async Task<byte[]> DownloadFileAsync(this Robot bot, GetFileResponse getFileResponse)
        {
            if (string.IsNullOrEmpty(getFileResponse?.Result?.FilePath))
                return null;

            using (var client = new WebClient())
            {
                try
                {
                    return await client.DownloadDataTaskAsync($"{Robot.ApiUrl}/file/bot{bot.ApiToken}/{getFileResponse.Result.FilePath}");
                }
                catch
                {
                    return null;
                }
            }
        }

    }
}
