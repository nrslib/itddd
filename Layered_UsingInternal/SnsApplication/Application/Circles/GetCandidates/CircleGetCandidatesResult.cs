using System.Collections.Generic;
using SnsApplication.Application.Users.Commons;

namespace SnsApplication.Application.Circles.GetCandidates
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
