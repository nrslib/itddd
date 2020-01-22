using System.Collections.Generic;
using System.Linq;
using EFInfrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using SnsApplication.Circles;
using SnsApplicationPort.Circles.GetCandidates;
using SnsApplicationPort.Users.Commons;
using SnsDomain.Models.Circles;

namespace EFInfrastructure.QueryService.Circles
{
    public class EFCircleGetCandidatesInteractor : ICircleGetCandidatesInputPort
    {
        public readonly ItdddDbContext context;

        public EFCircleGetCandidatesInteractor(ItdddDbContext context)
        {
            this.context = context;
        }

        public CircleGetCandidatesOutputData Handle(CircleGetCandidatesInputData inputData)
        {
            var circle = context.Circles
                .Include(x => x.CircleMembers)
                .ThenInclude(cm => cm.Circle)
                .FirstOrDefault(c => c.Id == inputData.CircleId);

            if (circle == null)
            {
                throw new CircleNotFoundException(new CircleId(inputData.CircleId));
            }

            var members = circle.CircleMembers
                .Select(m => m.UserId);

            if (circle.OwnerId != null)
            {
                members = members.Concat(new List<string> { circle.OwnerId });
            }

            var exceptUsers = members.ToHashSet();

            var page = inputData.Page;
            var size = inputData.Size;

            var chunk = context.Users
                .Where(u => !exceptUsers.Contains(u.Id))
                .Skip((page - 1) * size)
                .Take(size)
                .ToList();

            var candidates = chunk.Select(x => new UserData(x.Id, x.Name)).ToList();

            return new CircleGetCandidatesOutputData(candidates);
        }
    }
}
