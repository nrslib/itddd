using System;
using _18.SnsDomain.Models.Circles;

namespace _18.SnsApplication.Circles
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
