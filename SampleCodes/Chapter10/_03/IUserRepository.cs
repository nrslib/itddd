using System.Collections.Generic;

namespace _03
{
    public interface IUserRepository
    {
        User Find(UserId id);
        User Find(UserName name);
        User Find(MailAddress mail);
        List<User> FindAll();
        void Save(User user);
        void Delete(User user);
    }
}
