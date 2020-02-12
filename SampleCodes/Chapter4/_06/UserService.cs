using System;

namespace _06
{
    class UserService
    {
        public void ChangeName(User user, UserName name)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (name == null) throw new ArgumentNullException(nameof(name));

            user.Name = name;
        }
    }
}
