using System.Collections.Generic;
using ClArc.Sync.Core;
using SnsApplicationPort.Circles.Commons;

namespace SnsApplicationPort.Circles.GetAll
{
    public class CircleGetAllOutputData : IOutputData
    {
        public CircleGetAllOutputData(List<CircleData> circles)
        {
            Circles = circles;
        }

        public List<CircleData> Circles { get; }
    }
}
