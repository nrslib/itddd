using System;

namespace _07
{
    class MyProgram
    {
        public void Main()
        {
            var left = new User(new UserId("a"), "left");
            var right = new User(new UserId("b"), "right");
            Check(left, right);
        }

        void Check(User leftUser, User rightUser)
        {
            if (leftUser.Equals(rightUser))
            {
                Console.WriteLine("同一のユーザです");
            }
            else
            {
                Console.WriteLine("別のユーザです");
            }
        }
    }
}
