namespace YekanPedia.RoboTele.Service.Implement
{
    using System.Linq;
    using ManagementSystem.Domain.Entity;
    using System.Data.Entity;
    using Data.Context;
    using Interfaces;
    using System;

    public class UserService : IUserService
    {
        readonly IDbSet<User> _user;
        readonly IUnitOfWork _uow;
        public UserService(IUnitOfWork uow)
        {
            _uow = uow;
            _user = _uow.Set<User>();
        }

        public UpdateResult Update(string email, int telegramId)
        {
            try
            {
                var user = _user.FirstOrDefault(X => X.Email == email);
                if (user == null)
                    return UpdateResult.UserNotExist;
                if (user.Telegram == telegramId)
                    return UpdateResult.Success;
                user.Telegram = telegramId;
                _uow.SaveChanges();
                return UpdateResult.Success;
            }
            catch (Exception e)
            {
                return UpdateResult.Error;
            }
        }

        public bool IsTelegramAdded(int telegramId)
        {
            return _user.Count(X => X.Telegram == telegramId) != 0;
        }
    }
}
