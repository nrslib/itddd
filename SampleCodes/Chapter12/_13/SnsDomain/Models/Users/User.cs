using System;

namespace _13.SnsDomain.Models.Users
{
    public class User
    {
        // インスタンス変数はいずれも非公開
        private readonly UserId id;
        private UserName name;

        public User(UserId id, UserName name)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            if (name == null) throw new ArgumentNullException(nameof(name));

            this.id = id;
            this.name = name;
        }

        public void ChangeName(UserName name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            this.name = name;
        }

        public void Notify(IUserNotification note)
        {
            // 内部データを通知
            note.Id(id);
            note.Name(name);
        }
    }
}
