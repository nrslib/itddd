using System.Collections.Generic;

namespace _21
{
    interface IUserRepository
    {
        void Save(User user);
        void Delete(User user);
        List<User> FindAll();
        User Find(UserId id);
        User Find(UserName name);
    }
}
