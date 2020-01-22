using ClArc.Sync.Core;
using SnsApplicationPort.Circles.Commons;

namespace SnsApplicationPort.Circles.Get
{
    public class CircleGetOutputData : IOutputData
    {
        public CircleGetOutputData(CircleData circle)
        {
            Circle = circle;
        }

        public CircleData Circle { get; }
    }
}
