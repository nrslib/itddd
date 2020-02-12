using System;
using _13_to_17.App.Models.Users;

namespace _13_to_17.App.Application.Users
{
    public class CanNotRegisterUserException : Exception
    {
        public CanNotRegisterUserException(User user, string message) : base(message)
        {
            Id = user.Id.Value;
            Name = user.Name.Value;
        }

        public string Id { get; }
        public string Name { get; }
    }
}
