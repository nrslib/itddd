using ClArc.Sync.Core;

namespace SnsApplicationPort.Circles.Join
{
    public class CircleJoinInputData : IInputData<CircleJoinOutputData>
    {
        public CircleJoinInputData(string circleId, string memberId)
        {
            CircleId = circleId;
            MemberId = memberId;
        }

        public string CircleId { get; }
        public string MemberId { get; }
    }
}
