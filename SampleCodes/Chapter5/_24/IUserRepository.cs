namespace _24
{
    interface IUserRepository
    {
        void Save(User user);
        void UpdateName(UserId id, UserName name);
        void UpdateEmail(UserId id, Email mail);
        void UpdateAddress(UserId id, Address address);
        void Delete(User user);
        User Find(UserId id);
        User Find(UserName name);
    }
}
