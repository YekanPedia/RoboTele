namespace YekanPedia.RoboTele.Domain.Requests.Types
{
    using Http;
    using Bases;
    public class ReplyMarkupRequest : BaseTypeRequest
    {
        ForceReplyRequest _replyMarkupForceReply;
        ReplyKeyboardHideRequest _replyMarkupReplyKeyboardHide;
        ReplyKeyboardMarkupRequest _replyMarkupReplyKeyboardMarkup;

        public ReplyMarkupType ReplyMarkupType { get; private set; } = ReplyMarkupType.None;

        public ReplyKeyboardMarkupRequest ReplyMarkupReplyKeyboardMarkup
        {
            get { return _replyMarkupReplyKeyboardMarkup; }
            set
            {
                _replyMarkupReplyKeyboardMarkup = value;
                _replyMarkupReplyKeyboardHide = null;
                _replyMarkupForceReply = null;

                ReplyMarkupType = value == null ? ReplyMarkupType.None : ReplyMarkupType.ReplyKeyboardMarkup;
            }
        }

        public ReplyKeyboardHideRequest ReplyMarkupReplyKeyboardHide
        {
            get { return _replyMarkupReplyKeyboardHide; }
            set
            {
                _replyMarkupReplyKeyboardMarkup = null;
                _replyMarkupReplyKeyboardHide = value;
                _replyMarkupForceReply = null;

                ReplyMarkupType = value == null ? ReplyMarkupType.None : ReplyMarkupType.ReplyKeyboardHide;
            }
        }

        public ForceReplyRequest ReplyMarkupForceReply
        {
            get { return _replyMarkupForceReply; }
            set
            {
                _replyMarkupReplyKeyboardMarkup = null;
                _replyMarkupReplyKeyboardHide = null;
                _replyMarkupForceReply = value;

                ReplyMarkupType = value == null ? ReplyMarkupType.None : ReplyMarkupType.ForceReply;
            }
        }

        public override void Parse(HttpData httpData, string key)
        {
            switch (ReplyMarkupType)
            {
                case ReplyMarkupType.ReplyKeyboardMarkup:
                    ReplyMarkupReplyKeyboardMarkup.Parse(httpData, key);
                    break;

                case ReplyMarkupType.ReplyKeyboardHide:
                    ReplyMarkupReplyKeyboardHide.Parse(httpData, key);
                    break;

                case ReplyMarkupType.ForceReply:
                    ReplyMarkupForceReply.Parse(httpData, key);
                    break;
            }
        }
    }
}