﻿namespace YekanPedia.RoboTele.Domain.Responses.Types
{
    using Json;
    public class LocationResponse
    {
        public decimal Longitude { get; private set; }
        public decimal Latitude { get; private set; }

        public static LocationResponse Parse(JsonData data)
        {
            if (data == null || !data.Has("longitude") || !data.Has("latitude"))
            {
                return null;
            }

            return new LocationResponse
            {
                Longitude = data.Get<decimal>("longitude"),
                Latitude = data.Get<decimal>("latitude")
            };
        }
    }
}