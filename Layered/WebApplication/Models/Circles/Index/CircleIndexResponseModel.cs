using System.Collections.Generic;
using WebApplication.Models.Circles.Commons;

namespace WebApplication.Models.Circles.Index
{
    public class CircleIndexResponseModel
    {
        public CircleIndexResponseModel(List<CircleResponseModel> circles)
        {
            Circles = circles;
        }

        public List<CircleResponseModel> Circles { get; }
    }
}
