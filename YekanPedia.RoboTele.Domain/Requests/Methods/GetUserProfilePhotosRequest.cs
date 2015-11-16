﻿namespace YekanPedia.RoboTele.Domain.Requests.Methods
{
    using Bases;
    using Http;

    public class GetUserProfilePhotosRequest : BaseMethodRequest
    {
        public int UserId { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }

        public override string MethodName => "getUserProfilePhotos";

        public override HttpData Parse()
        {
            return new HttpData
            {
                Parameters = new HttpParameterList
                {
                    { "user_id", UserId },
                    { "offset", Offset },
                    { "limit", Limit }
                }
            };
        }
    }
}