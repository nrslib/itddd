using System.Collections.Generic;

namespace _20.EFInfrastructure.Services.Circles.GetSummaries
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
