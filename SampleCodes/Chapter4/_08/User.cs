using System;

namespace _08
{
    class User
    {
        private readonly UserId id;
        private UserName name;

        public User(UserId id, UserName name)
        {
            this.id = id;
            this.name = name;
        }

        public void ChangeUserName(UserName name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            this.name = name;
        }
    }
}
