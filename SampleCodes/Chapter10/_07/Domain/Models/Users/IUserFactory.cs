namespace _07.Domain.Models.Users
{
    public interface IUserFactory
    {
        User Create(UserName name);
    }

}
