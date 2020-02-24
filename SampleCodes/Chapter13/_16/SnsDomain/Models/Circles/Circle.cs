using System;
using System.Collections.Generic;
using _16.SnsDomain.Models.Users;

namespace _16.SnsDomain.Models.Circles
{
    public class Circle
    {
        private readonly CircleId id;
        private CircleName name;
        private User owner;
        private List<UserId> members;
        private DateTime created;

        public Circle(CircleId id, CircleName name, User owner, List<UserId> members, DateTime created)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (owner == null) throw new ArgumentNullException(nameof(owner));
            if (members == null) throw new ArgumentNullException(nameof(members));

            this.id = id;
            this.name = name;
            this.owner = owner;
            this.members = members;
            this.created = created;
        }

        public CircleId Id => id;
        public CircleName Name => name;
        public User Owner => owner;
        public List<UserId> Members => members;
        public DateTime Created => created;

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
