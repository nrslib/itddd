using SnsApplication.Application.Circles.GetCandidates;
using SnsApplication.Application.Circles.GetSummaries;

namespace SnsApplication.Application.Circles
{
    public interface ICircleQueryService
    {
        CircleGetSummariesResult GetSummaries(CircleGetSummariesCommand command);
        CircleGetCandidatesResult GetCandidates(CircleGetCandidatesCommand command);
    }
}
