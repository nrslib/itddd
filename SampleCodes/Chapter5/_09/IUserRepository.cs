namespace _09
{
    public interface IUserRepository
    {
        void Save(User user);
        Option<User> Find(UserName name);
    }
}
