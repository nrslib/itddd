namespace _26
{
    public interface IUserRepository
    {
        User Find(UserId id);
        User Find(UserName name);
        User Find(MailAddress mailAddress);
        void Save(User user);
        void Delete(User user);
    }
}
