namespace SnsDomain.Models.Users
{
    public interface IUserFactory
    {
        User Create(UserName name);
    }
}
