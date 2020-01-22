using System.Collections.Generic;
using ClArc.Sync.Core;

namespace SnsApplicationPort.Circles.GetSummaries
{
    public class CircleGetSummariesOutputData : IOutputData
    {
        public CircleGetSummariesOutputData(List<CircleSummaryData> summaries)
        {
            Summaries = summaries;
        }

        public List<CircleSummaryData> Summaries { get; }
    }
}
