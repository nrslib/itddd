namespace _19
{
    class FullName
    {
        public FullName(string firstName, string middleName, string lastName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string MiddleName { get; }
    }
}
