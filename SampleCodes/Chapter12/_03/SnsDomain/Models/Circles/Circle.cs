using System;
using System.Collections.Generic;
using _03.SnsDomain.Models.Users;

namespace _03.SnsDomain.Models.Circles
{
    public class Circle
    {
        private readonly CircleId id;
        private User owner;
        // メンバーは非公開にできる
        private List<User> members;
        private CircleName name;

        public Circle(CircleId id, CircleName name, User owner, List<User> members)
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

        public void Join(User member)
        {
            if (member == null) throw new ArgumentNullException(nameof(member));

            if (members.Count >= 29)
            {
                throw new CircleFullException(id);
            }

            members.Add(member);
        }
    }
}
