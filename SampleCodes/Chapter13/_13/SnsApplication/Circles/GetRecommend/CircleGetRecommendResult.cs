using System.Collections.Generic;
using System.Linq;
using _13.SnsDomain.Models.Circles;

namespace _13.SnsApplication.Circles.GetRecommend
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
