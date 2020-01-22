using System.Linq;
using SnsApplication.Application.Circles;
using SnsApplication.Application.Circles.GetCandidates;
using SnsApplication.Application.Circles.GetSummaries;
using SnsApplication.Application.Users.Commons;
using SnsApplication.Domain.Models.Circles;
using SnsApplication.Domain.Models.Users;

namespace InMemoryInfrastructure.QueryService
{
    public class InMemoryCircleQueryService : ICircleQueryService
    {
        private readonly IUserRepository userRepository;
        private readonly ICircleRepository circleRepository;

        public InMemoryCircleQueryService(IUserRepository userRepository, ICircleRepository circleRepository)
        {
            this.userRepository = userRepository;
            this.circleRepository = circleRepository;
        }

        public CircleGetSummariesResult GetSummaries(CircleGetSummariesCommand command)
        {
            var all = circleRepository.FindAll();

            var page = command.Page;
            var size = command.Size;

            var chunk = all
                .Skip((page - 1) * size)
                .Take(size);

            var summaries = chunk.Select(x =>
                {
                    var owner = userRepository.Find(x.Owner);
                    return new CircleSummaryData(x.Id.Value, owner.Name.Value);
                })
                .ToList();

            return new CircleGetSummariesResult(summaries);
        }

        public CircleGetCandidatesResult GetCandidates(CircleGetCandidatesCommand command)
        {
            var circleId = new CircleId(command.CircleId);
            var circle = circleRepository.Find(circleId);

            var members = circle.Members.Concat(new[] {circle.Owner}).ToHashSet();
            var candidates = userRepository.FindAll()
                .Where(x => !members.Contains(x.Id))
                .Skip((command.Page - 1) * command.Size)
                .Take(command.Size);

            var candidatesData = candidates.Select(x => new UserData(x)).ToList();

            return new CircleGetCandidatesResult(candidatesData);
        }
    }
}
