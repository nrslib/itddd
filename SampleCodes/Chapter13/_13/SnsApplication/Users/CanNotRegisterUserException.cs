using System;
using _13.SnsDomain.Models.Users;

namespace _13.SnsApplication.Users
{
    public class CanNotRegisterUserException : Exception
    {
        public CanNotRegisterUserException(
            User user, string message) : base(message)
        {
            Id = user.Id.Value;
            Name = user.Name.Value;
        }

        public string Id { get; }
        public string Name { get; }
    }
}
