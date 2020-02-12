namespace _23
{
    interface IUserRepository
    {
        void Save(User user);
        void UpdateName(UserId id, UserName name);
        void Delete(User user);
        User Find(UserId id);
        User Find(UserName name);
    }
}
