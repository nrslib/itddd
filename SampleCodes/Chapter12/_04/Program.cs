using System.Collections.Generic;
using _04.SnsDomain.Models.Circles;
using _04.SnsDomain.Models.Users;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            var circleId = new CircleId("test-circle-id");
            var circleName = new CircleName("test-circle-name");
            var owner = new User(
                new UserId("owner-user-id"),
                new UserName("owner-user-name")
            );
            var circle = new Circle(circleId, circleName, owner, new List<User>());

            var member = new User(
                new UserId("member-user-id"),
                new UserName("member-user-name")
            );
            circle.Join(member);
        }
    }
}
