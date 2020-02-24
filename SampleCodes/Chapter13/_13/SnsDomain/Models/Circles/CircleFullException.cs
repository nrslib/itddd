using System;

namespace _13.SnsDomain.Models.Circles
{
    public class CircleFullException : Exception
    {
        public CircleFullException(CircleId id, string message = null) : base(message)
        {
            Id = id;
        }

        public CircleId Id { get; }
    }
}
