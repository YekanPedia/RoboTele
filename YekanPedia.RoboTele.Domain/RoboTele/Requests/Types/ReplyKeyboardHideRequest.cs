namespace YekanPedia.RoboTele.Domain.Requests.Types
{
    using Http;
    using Json;
    using Bases;
    public class ReplyKeyboardHideRequest : BaseTypeRequest
    {
        public bool HideKeyboard => true;

        public bool Selective { get; set; }

        public override void Parse(HttpData httpData, string key)
        {
            httpData.Parameters.Add(key, JsonData.Serialize(new
            {
                hide_keyboard = HideKeyboard,
                selective = Selective
            }));
        }
    }
}