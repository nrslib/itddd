namespace _17
{
    interface IUserRepository
    {
        void Save(User user);
        User Find(UserName name);
    }
}
