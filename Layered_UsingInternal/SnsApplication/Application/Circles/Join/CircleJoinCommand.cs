namespace SnsApplication.Application.Circles.Join
{
    public class CircleJoinCommand
    {
        public CircleJoinCommand(string circleId, string memberId)
        {
            CircleId = circleId;
            MemberId = memberId;
        }

        public string CircleId { get; }
        public string MemberId { get; }
    }
}
