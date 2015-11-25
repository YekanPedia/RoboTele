namespace YekanPedia.RoboTele.Service.Interfaces
{
    public interface IUserService
    {
        UpdateResult Update(string email, int telegramId);
        bool IsTelegramAdded(int telegramId);
    }
    public enum UpdateResult
    {
        UserNotExist,
        Success,
        Error,
    }
}
