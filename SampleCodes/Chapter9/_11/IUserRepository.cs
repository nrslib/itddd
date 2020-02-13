namespace _11
{
    public interface IUserRepository
    {
        User Find(UserId id);
        void Save(User user);
        UserId NextIdentity();
    }
}
