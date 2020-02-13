namespace _11.Domain.Models.Users
{
    public interface IUserFactory
    {
        User Create(UserName name);
    }

}
