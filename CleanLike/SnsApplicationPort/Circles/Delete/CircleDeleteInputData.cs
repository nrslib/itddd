using ClArc.Sync.Core;

namespace SnsApplicationPort.Circles.Delete
{
    public class CircleDeleteInputData : IInputData<CircleDeleteOutputData>
    {
        public CircleDeleteInputData(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
