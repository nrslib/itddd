using ClArc.Sync.Core;

namespace SnsApplicationPort.Circles.Get
{
    public class CircleGetInputData : IInputData<CircleGetOutputData>
    {
        public CircleGetInputData(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
