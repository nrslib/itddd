namespace _47
{
    class Program
    {
        void CreateUser(string name)
        {
            var userName = new UserName(name);
            var user = new User(userName);

            // ...
        }

        void UpdateUser(string id, string name)
        {
            var userName = new UserName(name);

            // ...
        }
    }
}
