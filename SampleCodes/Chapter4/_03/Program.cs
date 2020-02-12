using System;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            var checkId = new UserId("check");
            var checkName = new UserName("checker");
            var checkObject = new User(checkId, checkName);

            var userId = new UserId("id");
            var userName = new UserName("nrs");
            var user = new User(userId, userName);

            // 重複確認専用インスタンスに問い合わせ
            var duplicateCheckResult = checkObject.Exists(user);
            Console.WriteLine(duplicateCheckResult);
        }
    }
}
