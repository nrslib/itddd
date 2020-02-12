namespace _18
{
    interface IUserRepository
    {
        void Save(User user);
        User Find(UserName name);
    }
}
