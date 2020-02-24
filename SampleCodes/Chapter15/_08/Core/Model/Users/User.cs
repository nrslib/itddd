using System;

namespace Core.Model.Users
{
    public class User
    {
        private UserName name;

        // 識別子 は UserId の まま
        public User(UserId id, UserName name)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            if (name == null) throw new ArgumentNullException(nameof(name));

            Id = id;
            this.name = name;
        }

        public UserId Id { get; }

        // 識別子 と なっ た UserName が 変更 でき て しまう
        public void ChangeName(UserName name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            this.name = name;
        }
    }
}
