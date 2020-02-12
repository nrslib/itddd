using System;

namespace _17
{
    public class UserUpdateCommand
    {
        public UserUpdateCommand(string id)
        {
            Id = id;
        }

        public string Id { get; }
        /// <summary> データが設定されると変更される </summary>
        public string Name { get; set; }
        /// <summary> データが設定されると変更される </summary>
        public string MailAddress { get; set; }
    }

    namespace AnotherOne
    {
        // 次のようにコンストラクタで名前やメールアドレスが任意であることを主張させてもよい
        public class UserUpdateCommand
        {
            public UserUpdateCommand(string id, string name = null, string mailAddress = null)
            {
                Id = id;
                Name = name;
                MailAddress = mailAddress;
            }

            public string Id { get; }
            public string Name { get; } // この場合セッターがなくなる
            public string MailAddress { get; } // この場合セッターがなくなる
        }
    }
}
