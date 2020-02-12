using System.Collections.Generic;
using System.Linq;

namespace _15
{
    class InMemoryUserRepository : IUserRepository
    {
        // テストケースによってはデータを確認したいことがある
        // 確認のための操作を外部から行えるようにするためpublicにしている
        public Dictionary<UserId, User> Store { get; } = new Dictionary<UserId, User>();

        public User Find(UserName name)
        {
            foreach (var elem in Store.Values)
            {
                if (elem.Name.Equals(name))
                {
                    return Clone(elem);
                }
            }

            return null;
        }

        public void Save(User user)
        {
            // 保存時もディープコピーを行う
            Store[user.Id] = Clone(user);
        }

        // ディープコピーを行うメソッド
        private User Clone(User user)
        {
            return new User(user.Id, user.Name);
        }
    }
}
