using System;

namespace _23
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(UserId userId)
        {
            UserId = userId?.Value;
        }

        public string UserId { get; }
    }
}
