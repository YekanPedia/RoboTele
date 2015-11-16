
namespace YekanPedia.RoboTele.Domain
{
    using System;

    public static class DateTimeHelper
    {
        internal static DateTime? ToDateTime(this int? timestamp)
        {
            if (timestamp.HasValue)
            {
                return new DateTime(1970, 1, 1).AddSeconds(timestamp.Value);
            }
            return null;
        }
    }
}
