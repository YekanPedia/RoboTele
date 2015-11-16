namespace YekanPedia.RoboTele.Domain.Http
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public class HttpParameterList : List<HttpParameter>
    {
        public void Add(string key, string value)
        {
            Add(new HttpParameter
            {
                Key = key,
                Value = !string.IsNullOrEmpty(value) ?
                    value : string.Empty
            });
        }

        public void Add(string key, bool? value)
        {
            Add(new HttpParameter
            {
                Key = key,
                Value = value.HasValue && value.Value ?
                    "1" : "0"
            });
        }

        public void Add(string key, int? value)
        {
            Add(new HttpParameter
            {
                Key = key,
                Value = value.HasValue ?
                    Convert.ToString(value.Value) : string.Empty
            });
        }

        public void Add(string key, float? value)
        {
            Add(new HttpParameter
            {
                Key = key,
                Value = value.HasValue ?
                    Convert.ToString(value.Value, CultureInfo.InvariantCulture) : string.Empty
            });
        }
    }
}