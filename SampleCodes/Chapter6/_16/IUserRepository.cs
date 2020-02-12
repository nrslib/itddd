namespace _16
{
    public interface IUserRepository
    {
        User Find(UserId id);
        User Find(UserName name);
        void Save(User user);
        void Delete(User user);
    }
}
