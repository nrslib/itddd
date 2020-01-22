using System;

namespace SnsDomain.Models.Circles
{
    public class CircleFullException : Exception
    {
        public CircleFullException(CircleId id, string message) : base(message)
        {
            Id = id;
        }

        public CircleId Id { get; }
    }
}
