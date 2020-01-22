using System.Collections.Generic;
using WebApplication.Models.Users.Commons;

namespace WebApplication.Models.Circles.GetCandidates
{
    public class CircleGetCandidatesResponseModel
    {
        public CircleGetCandidatesResponseModel(List<UserResponseModel> users)
        {
            Users = users;
        }

        public List<UserResponseModel> Users { get; set; }
    }
}
