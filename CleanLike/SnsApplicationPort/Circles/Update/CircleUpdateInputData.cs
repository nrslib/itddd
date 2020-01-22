using ClArc.Sync.Core;

namespace SnsApplicationPort.Circles.Update
{
    public class CircleUpdateInputData : IInputData<CircleUpdateOutputData>
    {
        public CircleUpdateInputData(string id, string name = null)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; }
        public string Name { get; }
    }
}
