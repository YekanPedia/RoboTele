namespace YekanPedia.RoboTele.Domain.Requests.Types
{
    using System.Collections.Generic;
    using Http;
    using Json;
    using Bases;
    public class ReplyKeyboardMarkupRequest : BaseTypeRequest
    {
        public List<List<string>> Keyboard { get; set; }
        public bool ResizeKeyboard { get; set; }
        public bool OneTimeKeyboard { get; set; }
        public bool Selective { get; set; }

        public override void Parse(HttpData httpData, string key)
        {
            httpData.Parameters.Add(key, JsonData.Serialize(new
            {
                keyboard = Keyboard,
                resize_keyboard = ResizeKeyboard,
                one_time_keyboard = OneTimeKeyboard,
                selective = Selective
            }));
        }
    }
}