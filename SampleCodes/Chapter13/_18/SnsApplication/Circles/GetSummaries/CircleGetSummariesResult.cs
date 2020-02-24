using System.Collections.Generic;

namespace _18.SnsApplication.Circles.GetSummaries
{
    public class CircleGetSummariesResult
    {
        public CircleGetSummariesResult(List<CircleSummaryData> summaries)
        {
            Summaries = summaries;
        }

        public List<CircleSummaryData> Summaries { get; }
    }
}
