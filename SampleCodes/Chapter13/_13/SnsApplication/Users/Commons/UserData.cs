using _13.SnsDomain.Models.Users;

namespace _13.SnsApplication.Users.Commons
{
    public class UserData
    {
        public UserData(User user) : this(user.Id.Value, user.Name.Value)
        {
        }

        public UserData(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; }
        public string Name { get; }
    }
}
