using System;
using System.Linq;
using System.Collections.Generic;
using _03.SnsDomain.Models.Users;

namespace _03.SnsDomain.Models.Circles
{
    public class Circle
    {
        private readonly CircleId id;
        private CircleName name;
        private User owner;
        private List<UserId> members;

        public Circle(CircleId id, CircleName name, User owner, List<UserId> members)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (owner == null) throw new ArgumentNullException(nameof(owner));
            if (members == null) throw new ArgumentNullException(nameof(members));

            this.id = id;
            this.name = name;
            this.owner = owner;
            this.members = members;
        }

        public CircleId Id => id;
        public CircleName Name => name;
        public User Owner => owner;
        public List<UserId> Members => members;

        // ユーザのリポジトリを受け取る？
        public bool IsFull(IUserRepository userRepository)
        {
            var users = userRepository.Find(Members);
            var premiumUserNumber = users.Count(user => user.IsPremium);
            var circleUpperLimit = premiumUserNumber < 10 ? 30 : 50;
            return CountMembers() >= circleUpperLimit;
        }

        public int CountMembers()
        {
            return members.Count + 1;
        }

        public void ChangeName(CircleName name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            this.name = name;
        }
    }
}
