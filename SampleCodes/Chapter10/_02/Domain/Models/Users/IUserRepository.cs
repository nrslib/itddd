using System.Collections.Generic;

namespace _02.Domain.Models.Users
{
    public interface IUserRepository
    {
        User Find(UserId id);
        User Find(UserName name);
        List<User> FindAll();
        void Save(User user);
        void Delete(User user);
    }
}
