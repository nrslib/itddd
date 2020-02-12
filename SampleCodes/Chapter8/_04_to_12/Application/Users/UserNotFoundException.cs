using System;
using _04_to_12.Models.Users;

namespace _04_to_12.Application.Users
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(UserId id)
        {
            Id = id.Value;
        }

        public UserNotFoundException(UserId id, string message) : base(message)
        {
            Id = id.Value;
        }

        public string Id { get; }
    }
}
