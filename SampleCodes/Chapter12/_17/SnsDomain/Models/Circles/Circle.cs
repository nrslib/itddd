using System;
using System.Collections.Generic;
using System.Linq;
using _17.SnsDomain.Models.Users;

namespace _17.SnsDomain.Models.Circles
{
    public class Circle
    {
        private readonly CircleId id;
        private CircleName name;
        private User owner;
        private List<User> members;

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
        public User Owner => owner;
        public List<User> Members => members;

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

            members.Add(user);
        }

        public void ChangeMemberName(UserId id, UserName name)
        {
            var target = members.FirstOrDefault(x => x.Id.Equals(id));
            if (target != null)
            {
                target.ChangeName(name);
            }
        }
    }
}
