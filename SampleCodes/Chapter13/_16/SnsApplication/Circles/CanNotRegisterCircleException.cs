using System;
using _16.SnsDomain.Models.Circles;

namespace _16.SnsApplication.Circles
{
    public class CanNotRegisterCircleException : Exception
    {
        public CanNotRegisterCircleException(Circle circle, string message) : base(message)
        {
            Id = circle.Id.Value;
            Name = circle.Name.Value;
        }

        public string Id { get; }
        public string Name { get; }
    }
}
