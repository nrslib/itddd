using System.Collections.Generic;
using SnsApplication.Users.Commons;

namespace SnsApplication.Circles.GetCandidates
{
    public class CircleGetCandidatesResult
    {
        public CircleGetCandidatesResult(List<UserData> users)
        {
            Users = users;
        }

        public List<UserData> Users { get; }
    }
}
