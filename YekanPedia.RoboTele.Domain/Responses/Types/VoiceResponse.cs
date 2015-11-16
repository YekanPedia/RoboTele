﻿namespace YekanPedia.RoboTele.Domain.Responses.Types
{
    using Json;
    public class VoiceResponse
    {
        public string FileId { get; private set; }
        public int Duration { get; private set; }
        public string MimeType { get; private set; }
        public int? FileSize { get; private set; }

        public static VoiceResponse Parse(JsonData data)
        {
            if (data == null || !data.Has("file_id") || !data.Has("duration"))
            {
                return null;
            }

            return new VoiceResponse
            {
                FileId = data.Get<string>("file_id"),
                Duration = data.Get<int>("duration"),
                MimeType = data.Get<string>("mime_type"),
                FileSize = data.Get<int?>("file_size")
            };
        }
    }
}