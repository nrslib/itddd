using System;

namespace _18
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
