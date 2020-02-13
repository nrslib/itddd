using System.Collections.Generic;

namespace _14.Domain.Models.Users
{
    public interface IUserRepository
    {
        User Find(UserId id);
        User Find(UserName name);
        void Save(User user);
        void Delete(User user);
    }
}
