using SnsApplication.Circles.GetCandidates;
using SnsApplication.Circles.GetSummaries;

namespace SnsApplication.Circles
{
    public interface ICircleQueryService
    {
        CircleGetSummariesResult GetSummaries(CircleGetSummariesCommand command);
        CircleGetCandidatesResult GetCandidates(CircleGetCandidatesCommand command);
    }
}
