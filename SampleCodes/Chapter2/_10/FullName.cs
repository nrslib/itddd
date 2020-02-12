namespace _10
{
    class FullName
    {
        public FullName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }
        public string LastName { get; private set; }

        public void ChangeLastName(string name)
        {
            LastName = name;
        }
    }
}
