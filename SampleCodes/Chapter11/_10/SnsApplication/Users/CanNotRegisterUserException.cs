using System;
using _10.SnsDomain.Models.Users;

namespace _10.SnsApplication.Users
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
