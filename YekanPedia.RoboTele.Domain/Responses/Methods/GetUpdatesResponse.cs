﻿namespace YekanPedia.RoboTele.Domain.Responses.Methods
{
    using System.Collections.Generic;
    using Json;
    using Bases;
    using Types;
    public class GetUpdatesResponse : BaseMethodResponse
    {
        public List<UpdateResponse> Result { get; private set; }

        public static GetUpdatesResponse Parse(JsonData data)
        {
            if (data == null)
            {
                return null;
            }

            var getUpdatesResponse = new GetUpdatesResponse
            {
                Ok = data.Get<bool>("ok"),
                ErrorCode = data.Get<int?>("error_code"),
                Description = data.Get<string>("description"),
                Result = new List<UpdateResponse>()
            };

            foreach (var result in data.GetJsonList("result"))
            {
                getUpdatesResponse.Result.Add(UpdateResponse.Parse(result));
            }

            return getUpdatesResponse;
        }
    }
}