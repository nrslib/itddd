using System;

namespace _28
{
    public class CanNotRegisterUserException : Exception
    {
        public CanNotRegisterUserException(User user, string message) : base(message)
        {
            Id = user?.Id?.Value;
            MailAddress = user?.MailAddress?.Value;
        }

        
        public CanNotRegisterUserException(MailAddress mailAddress, string message = null) : base(message)
        {
            MailAddress = mailAddress?.Value;
        }

        public string Id { get; }
        public string MailAddress { get; }
    }
}
