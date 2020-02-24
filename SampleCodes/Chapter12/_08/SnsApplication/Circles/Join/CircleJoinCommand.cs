namespace _08.SnsApplication.Circles.Join
{
    public class CircleJoinCommand
    {
        public CircleJoinCommand(string userId, string circleId)
        {
            UserId = userId;
            CircleId = circleId;
        }

        public string UserId { get; }
        public string CircleId { get; }
    }
}
