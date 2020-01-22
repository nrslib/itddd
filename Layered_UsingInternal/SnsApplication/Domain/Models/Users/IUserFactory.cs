namespace SnsApplication.Domain.Models.Users
{
    public interface IUserFactory
    {
        User Create(UserName name);
    }
}
