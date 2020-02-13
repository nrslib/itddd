using System;

namespace _14
{
    public class Circle
    {
        public Circle(UserId ownerId, CircleName name)
        {
            if (ownerId == null) throw new ArgumentNullException(nameof(ownerId));
            if (name == null) throw new ArgumentNullException(nameof(name));

            OwnerId = ownerId;
            Name = name;
        }

        public UserId OwnerId { get; }
        public CircleName Name { get; }
    }
}
