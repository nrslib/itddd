using System;
using _04_to_12.Models.Users;

namespace _04_to_12.Application.Users
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
