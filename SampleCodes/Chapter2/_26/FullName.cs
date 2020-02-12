using System;

namespace _26
{
    class FullName
    {
        private readonly Name firstName;
        private readonly Name lastName;

        public FullName(Name firstName, Name lastName)
        {
            if (firstName == null) throw new ArgumentNullException(nameof(firstName));
            if (lastName == null) throw new ArgumentNullException(nameof(lastName));

            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
}
