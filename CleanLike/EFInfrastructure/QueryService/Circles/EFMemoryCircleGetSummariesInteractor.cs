using System.Linq;
using EFInfrastructure.Contexts;
using SnsApplicationPort.Circles.GetSummaries;

namespace EFInfrastructure.QueryService.Circles
{
    public class EFMemoryCircleGetSummariesInteractor : ICircleGetSummariesInputPort
    {
        public readonly ItdddDbContext context;

        public EFMemoryCircleGetSummariesInteractor(ItdddDbContext context)
        {
            this.context = context;
        }

        public CircleGetSummariesOutputData Handle(CircleGetSummariesInputData inputData)
        {
            var all =
                from circle in context.Circles
                join owner in context.Users
                    on circle.OwnerId equals owner.Id
                select new { circle, owner };

            var page = inputData.Page;
            var size = inputData.Size;

            var chunk = all
                .Skip((page - 1) * size)
                .Take(size);

            var summaries = chunk
                .Select(x => new CircleSummaryData(x.circle.Id, x.owner.Name))
                .ToList();

            return new CircleGetSummariesOutputData(summaries);
        }
    }
}
