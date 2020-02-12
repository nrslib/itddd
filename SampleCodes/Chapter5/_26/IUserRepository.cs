namespace _26
{
    interface IUserRepository
    {
        void Save(User user);
        void Delete(User user);
        User Find(UserId id);
        User Find(UserName name);
    }
}
