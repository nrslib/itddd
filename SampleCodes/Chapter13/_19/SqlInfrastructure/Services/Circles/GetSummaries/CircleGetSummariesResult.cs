using System.Collections.Generic;

namespace _19.SqlInfrastructure.Services.Circles.GetSummaries
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
