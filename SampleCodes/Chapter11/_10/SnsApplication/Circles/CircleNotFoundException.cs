using System;
using _10.SnsDomain.Models.Circles;

namespace _10.SnsApplication.Circles
{
    public class CircleNotFoundException : Exception
    {
        public CircleNotFoundException(CircleId id)
        {
            Id = id.Value;
        }

        public CircleNotFoundException(CircleId id, string message) : base(message)
        {
            Id = id.Value;
        }

        public string Id { get; }
    }
}
