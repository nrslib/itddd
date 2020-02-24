using System.Collections.Generic;
using System.Linq;
using _11.SnsDomain.Models.Circles;

namespace _11.SnsApplication.Circles.GetRecommend
{
    public class CircleGetRecommendResult
    {
        public CircleGetRecommendResult(List<Circle> recommendCircles)
        {
            recommendCircles.Select(x => new CircleSummaryData(x));
        }

        public List<CircleSummaryData> Summaries { get; }
    }
}
