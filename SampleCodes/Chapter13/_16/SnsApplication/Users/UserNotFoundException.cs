using System;
using _16.SnsDomain.Models.Users;

namespace _16.SnsApplication.Users
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
