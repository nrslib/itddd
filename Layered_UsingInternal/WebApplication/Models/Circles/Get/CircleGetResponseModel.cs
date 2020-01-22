using WebApplication.Models.Circles.Commons;
using WebApplication.Models.Users.Commons;

namespace WebApplication.Models.Circles.Get
{
    public class CircleGetResponseModel
    {
        public CircleGetResponseModel(CircleResponseModel circle, UserResponseModel owner)
        {
            Circle = circle;
            Owner = owner;
        }
        
        public CircleResponseModel Circle { get; }

        public UserResponseModel Owner { get; }
    }
}
