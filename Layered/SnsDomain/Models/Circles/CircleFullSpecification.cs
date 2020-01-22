using System.Collections.Generic;
using System.Linq;
using SnsDomain.Models.Users;

namespace SnsDomain.Models.Circles
{
    public class CircleFullSpecification
    {
        private readonly IUserRepository userRepository;

        public CircleFullSpecification(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public bool IsSatisfiedBy(Circle circle)
        {
            var membersCount = circle.CountMembers();
            if (membersCount < 30)
            {
                return false;
            }

            var members = circle.GetMembers();
            var users = userRepository.Find(members);
            var premiumMemberCount = CountPremiumMember(users);
            var max = premiumMemberCount > 10 ? 50 : 30;

            return membersCount >= max;
        }

        private int CountPremiumMember(List<User> members)
        {
            return members.Count(x => x.Type == UserType.Premium);
        }
    }
}
