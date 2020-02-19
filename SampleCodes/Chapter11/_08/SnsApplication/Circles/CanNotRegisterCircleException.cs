using System;
using _08.SnsDomain.Models.Circles;

namespace _08.SnsApplication.Circles
{
    class CanNotRegisterCircleException : Exception
    {
        public CanNotRegisterCircleException(Circle circle, string message) : base(message)
        {
            Id = circle?.Id.Value;
        }

        public string Id;
    }
}
