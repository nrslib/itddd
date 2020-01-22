using System.Collections.Generic;

namespace SnsApplication.Application.Circles.GetSummaries
{
    public class CircleGetSummariesResult
    {
        public CircleGetSummariesResult(List<CircleSummaryData> summuries)
        {
            Summuries = summuries;
        }

        public List<CircleSummaryData> Summuries { get; }
    }
}
