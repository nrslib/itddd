namespace _02.SnsDomain.Models.Users
{
    public interface IUserFactory
    {
        User Create(UserName name);
    }

}
