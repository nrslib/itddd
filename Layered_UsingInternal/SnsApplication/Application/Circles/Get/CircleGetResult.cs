using SnsApplication.Application.Circles.Commons;

namespace SnsApplication.Application.Circles.Get
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
