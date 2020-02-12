namespace _08
{
    interface IUserRepository
    {
        void Save(User user);
        User Find(UserName name);
        public bool Exists(UserName name);
    }
}
