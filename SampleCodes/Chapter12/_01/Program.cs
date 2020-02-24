using System;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            var id = new UserId("test-id");
            var name = new UserName("CurrentName");
            var user = new User(id, name);

            var userName = new UserName("NewName");

            // NG
            user.Name = userName;

            // OK
            user.ChangeName(userName);
        }
    }
}
