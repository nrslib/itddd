using System;

namespace _21
{
    public class CanNotRegisterUserException : Exception
    {
        public CanNotRegisterUserException(User user, string message) : base(message)
        {
            Id = user?.Id?.Value;
            Name = user?.Name?.Value;
        }

        public CanNotRegisterUserException(UserName name, string message) : base(message)
        {
            Name = name?.Value;
        }

        public string Id { get; }
        public string Name { get; }
    }
}
