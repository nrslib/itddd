using System;
using System.Collections.Generic;
using _02.SnsDomain.Models.Users;

namespace _02.SnsDomain.Models.Circles
{
    public class Circle
    {
        public Circle(CircleId id, CircleName name, User owner, List<User> members)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (owner == null) throw new ArgumentNullException(nameof(owner));
            if (members == null) throw new ArgumentNullException(nameof(members));

            Id = id;
            Name = name;
            Owner = owner;
            Members = members;
        }

        public CircleId Id { get; }
        public CircleName Name { get; private set; }
        public User Owner { get; private set; }
        public List<User> Members { get; private set; }
    }
}