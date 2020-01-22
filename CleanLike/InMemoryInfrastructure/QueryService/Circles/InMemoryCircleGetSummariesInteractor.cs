using System.Linq;
using SnsApplicationPort.Circles.GetSummaries;
using SnsDomain.Models.Circles;
using SnsDomain.Models.Users;

namespace InMemoryInfrastructure.QueryService.Circles
{
    public class InMemoryCircleGetSummariesInteractor : ICircleGetSummariesInputPort
    {
        private readonly IUserRepository userRepository;
        private readonly ICircleRepository circleRepository;

        public InMemoryCircleGetSummariesInteractor(IUserRepository userRepository, ICircleRepository circleRepository)
        {
            this.userRepository = userRepository;
            this.circleRepository = circleRepository;
        }

        public CircleGetSummariesOutputData Handle(CircleGetSummariesInputData inputData)
        {
            var all = circleRepository.FindAll();

            var page = inputData.Page;
            var size = inputData.Size;

            var chunk = all
                .Skip((page - 1) * size)
                .Take(size);

            var summaries = chunk.Select(x =>
                {
                    var owner = userRepository.Find(x.Owner);
                    return new CircleSummaryData(x.Id.Value, owner.Name.Value);
                })
                .ToList();

            return new CircleGetSummariesOutputData(summaries);
        }
    }
}
