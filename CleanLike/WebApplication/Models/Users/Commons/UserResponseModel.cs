using SnsApplicationPort.Users.Commons;

namespace WebApplication.Models.Users.Commons
{
    public class UserResponseModel
    {
        public UserResponseModel(UserData source) : this(source.Id, source.Name)
        {
        }

        public UserResponseModel(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; }
        public string Name { get; }
    }
}