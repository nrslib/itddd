using System;

namespace _07
{
    class InMemoryUserFactory : IUserFactory
    {
        // 現在のID
        private int currentId;

        public User Create(UserName name)
        {
            // ユーザが生成されるたびにインクリメントする
            currentId++;

            return new User(
                new UserId(currentId.ToString()),
                name
            );
        }
    }
}
