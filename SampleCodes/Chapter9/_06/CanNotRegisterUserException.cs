using System;

namespace _06
{
    public class CanNotRegisterUserException : Exception
    {
        public CanNotRegisterUserException(User user, string message = null) : base(message)
        {
            Id = user?.Id?.Value;
            Name = user?.Name?.Value;
        }

        public string Id { get; }
        public string Name { get; }
    }
}
