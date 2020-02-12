using System.Collections.Generic;

namespace _28
{
    interface IUserRepository
    {
        void Save(User user);
        void Delete(User user);
        User Find(UserId id);
        User Find(UserName name);
        // オーバーロードがサポートされていない言語の場合は命名によりバリエーションを増やす
        // User FindByUserName(UserName name);
    }
}
