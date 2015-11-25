namespace YekanPedia.RoboTele.Domain.Http
{
    using System;
    using System.Collections.Generic;
    public class HttpFileList : List<HttpFile>
    {
        public void Add(string key, string extension, byte[] file, string contentType)
        {
            Add(new HttpFile
            {
                Key = key,
                File = file,
                FileName = $"{Guid.NewGuid()}.{extension}",
                ContentType = contentType
            });
        }
    }
}