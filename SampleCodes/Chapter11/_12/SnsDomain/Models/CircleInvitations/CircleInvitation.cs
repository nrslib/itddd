using _12.SnsDomain.Models.Circles;
using _12.SnsDomain.Models.Users;

namespace _12.SnsDomain.Models.CircleInvitations
{
    public class CircleInvitation
    {
        public CircleInvitation(Circle circle, User fromUser, User invitedUser)
        {
            Circle = circle;
            FromUser = fromUser;
            InvitedUser = invitedUser;
        }

        public Circle Circle { get; }
        public User FromUser { get; }
        public User InvitedUser { get; }
    }
}
