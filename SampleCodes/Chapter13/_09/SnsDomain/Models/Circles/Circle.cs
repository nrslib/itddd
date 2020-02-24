using System;
using System.Collections.Generic;
using _09.SnsDomain.Models.Users;

namespace _09.SnsDomain.Models.Circles
{
    public class Circle
    {
        private readonly CircleId id;
        private CircleName name;
        private UserId owner;
        private List<UserId> members;

        public Circle(CircleId id, CircleName name, UserId owner, List<UserId> members)
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
        public UserId Owner => owner;
        public List<UserId> Members => members;

        public bool IsFull()
        {
            return CountMembers() >= 30;
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
