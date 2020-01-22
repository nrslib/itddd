using System.Collections.Generic;
using System.Linq;
using EFInfrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using SnsApplication.Application.Circles;
using SnsApplication.Application.Circles.GetCandidates;
using SnsApplication.Application.Circles.GetSummaries;
using SnsApplication.Application.Users.Commons;
using SnsApplication.Domain.Models.Circles;

namespace EFInfrastructure.QueryService.EFQueryService
{
    public class EFCircleQueryService : ICircleQueryService
    {
        public readonly ItdddDbContext context;

        public EFCircleQueryService(ItdddDbContext context)
        {
            this.context = context;
        }

        public CircleGetSummariesResult GetSummaries(CircleGetSummariesCommand command)
        {
            var all =
                from circle in context.Circles
                join owner in context.Users
                    on circle.OwnerId equals owner.Id
                select new {circle, owner};

            var page = command.Page;
            var size = command.Size;

            var chunk = all
                .Skip((page - 1) * size)
                .Take(size);

            var summaries = chunk
                .Select(x => new CircleSummaryData(x.circle.Id, x.owner.Name))
                .ToList();

            return new CircleGetSummariesResult(summaries);
        }

        public CircleGetCandidatesResult GetCandidates(CircleGetCandidatesCommand command)
        {
            var circle = context.Circles
                .Include(x => x.CircleMembers)
                .ThenInclude(cm => cm.Circle)
                .FirstOrDefault(c => c.Id == command.CircleId);

            if (circle == null)
            {
                throw new CircleNotFoundException(new CircleId(command.CircleId));
            }

            var members = circle.CircleMembers
                .Select(m => m.UserId);

            if (circle.OwnerId != null)
            {
                members = members.Concat(new List<string> {circle.OwnerId});
            }

            var exceptUsers = members.ToHashSet();
                
            var page = command.Page;
            var size = command.Size;

            var chunk = context.Users
                .Where(u => !exceptUsers.Contains(u.Id))
                .Skip((page - 1) * size)
                .Take(size)
                .ToList();

            var candidates = chunk.Select(x => new UserData(x.Id, x.Name)).ToList();

            return new CircleGetCandidatesResult(candidates);
        }
    }
}
