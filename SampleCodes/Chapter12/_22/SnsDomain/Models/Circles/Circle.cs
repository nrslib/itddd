using System;
using System.Collections.Generic;
using _22.SnsDomain.Models.Users;

namespace _22.SnsDomain.Models.Circles
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

        public bool IsFull()
        {
            return members.Count >= 29;
        }

        public void Join(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            if (IsFull())
            {
                throw new CircleFullException(id);
            }

            members.Add(user.Id);
        }

        public void ChangeName(CircleName name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            this.name = name;
        }
    }
}
