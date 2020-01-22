using System.Collections.Generic;
using SnsApplication.Circles.Commons;

namespace SnsApplication.Circles.GetAll
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
