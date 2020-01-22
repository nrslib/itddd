using System;
using SnsApplication.Domain.Models.Users;

namespace SnsApplication.Application.Users
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
