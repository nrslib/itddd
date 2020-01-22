using ClArc.Sync.Core;

namespace SnsApplicationPort.Circles.Create
{
    public class CircleCreateOutputData : IOutputData
    {
        public CircleCreateOutputData(string createdCircleId)
        {
            CreatedCircleId = createdCircleId;
        }

        public string CreatedCircleId { get; }
    }
}
