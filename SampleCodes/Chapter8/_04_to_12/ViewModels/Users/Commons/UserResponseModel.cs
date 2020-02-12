using _04_to_12.Application.Users.Commons;

namespace _04_to_12.ViewModels.Users.Commons
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