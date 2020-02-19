namespace _12.SnsApplication.Circles.Invite
{
    public class CircleInviteCommand
    {
        public CircleInviteCommand(string circleId, string fromUserId, string invitedUserId)
        {
            CircleId = circleId;
            FromUserId = fromUserId;
            InvitedUserId = invitedUserId;
        }

        public string CircleId { get; set; }
        public string FromUserId { get; set; }
        public string InvitedUserId { get; set; }
    }
}
