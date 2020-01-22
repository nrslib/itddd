using ClArc.Sync.Core;

namespace SnsApplicationPort.Circles.Create
{
    public class CircleCreateInputData : IInputData<CircleCreateOutputData>
    {
        public CircleCreateInputData(string name, string ownerId)
        {
            Name = name;
            OwnerId = ownerId;
        }

        public string Name { get; }
        public string OwnerId { get; }
    }
}
