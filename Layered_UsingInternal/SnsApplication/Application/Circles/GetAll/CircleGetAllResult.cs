using System.Collections.Generic;
using SnsApplication.Application.Circles.Commons;

namespace SnsApplication.Application.Circles.GetAll
{
    public class CircleGetAllResult
    {
        public CircleGetAllResult(List<CircleData> circles)
        {
            Circles = circles;
        }

        public List<CircleData> Circles { get; }
    }
}
