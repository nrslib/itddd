namespace _06.Domain.Models.Users
{
    public interface IUserFactory
    {
        User Create(UserName name);
    }

}
