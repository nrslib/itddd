using System.Collections.Generic;
using ClArc.Sync.Core;
using SnsApplicationPort.Users.Commons;

namespace SnsApplicationPort.Circles.GetCandidates
{
    public class CircleGetCandidatesOutputData : IOutputData
    {
        public CircleGetCandidatesOutputData(List<UserData> users)
        {
            Users = users;
        }

        public List<UserData> Users { get; }
    }
}
