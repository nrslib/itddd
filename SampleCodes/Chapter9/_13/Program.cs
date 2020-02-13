using System;
using System.Collections.Generic;
using System.Text;

namespace _13
{
    class Program
    {
        public static void Main(string[] args)
        {
            var user = new User(new UserId("test-id"), new UserName("test-name"));

            var circle = new Circle(
                user.Id, // ゲッターによりユーザのIDを取得
                new CircleName("my circle")
            );
        }
    }
}
