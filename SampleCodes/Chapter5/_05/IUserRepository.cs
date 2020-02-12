namespace _05
{
    interface IUserRepository
    {
        void Save(User user);
        User Find(UserName name);
    }
}
