namespace _05
{
    interface IUserRepository
    {
        void Save(User user);
        User Find(UserName name);
        bool Exists(User user);
    }
}
