using System;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            var userId = new UserId("id");
            var userName = new UserName("nrs");
            var user = new User(userId, userName);

            // 生成したオブジェクト自身に問い合わせをすることになる
            var duplicateCheckResult = user.Exists(user);
            Console.WriteLine(duplicateCheckResult); // true? false?
        }
    }
}
