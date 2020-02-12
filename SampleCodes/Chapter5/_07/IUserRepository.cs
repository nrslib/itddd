namespace _07
{
    interface IUserRepository
    {
        void Save(User user);
        User Find(UserName name);
        bool Exists(User user);
    }
}
