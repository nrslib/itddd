using SnsApplication.Circles.Commons;

namespace SnsApplication.Circles.Get
{
    public class CircleGetResult
    {
        public CircleGetResult(CircleData circle)
        {
            Circle = circle;
        }

        public CircleData Circle { get; }
    }
}
