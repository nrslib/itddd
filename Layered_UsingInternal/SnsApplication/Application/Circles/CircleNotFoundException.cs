using System;
using SnsApplication.Domain.Models.Circles;

namespace SnsApplication.Application.Circles
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
