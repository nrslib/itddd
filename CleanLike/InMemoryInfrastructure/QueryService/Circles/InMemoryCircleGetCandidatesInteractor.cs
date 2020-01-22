using System.Linq;
using SnsApplicationPort.Circles.GetCandidates;
using SnsApplicationPort.Users.Commons;
using SnsDomain.Models.Circles;
using SnsDomain.Models.Users;

namespace InMemoryInfrastructure.QueryService.Circles
{
    public class InMemoryCircleGetCandidatesInteractor : ICircleGetCandidatesInputPort
    {
        private readonly IUserRepository userRepository;
        private readonly ICircleRepository circleRepository;

        public InMemoryCircleGetCandidatesInteractor(IUserRepository userRepository, ICircleRepository circleRepository)
        {
            this.userRepository = userRepository;
            this.circleRepository = circleRepository;
        }

        public CircleGetCandidatesOutputData Handle(CircleGetCandidatesInputData inputData)
        {
            var circleId = new CircleId(inputData.CircleId);
            var circle = circleRepository.Find(circleId);

            var members = circle.Members.Concat(new[] { circle.Owner }).ToHashSet();
            var candidates = userRepository.FindAll()
                .Where(x => !members.Contains(x.Id))
                .Skip((inputData.Page - 1) * inputData.Size)
                .Take(inputData.Size);

            var candidatesData = candidates.Select(toUserData).ToList();

            return new CircleGetCandidatesOutputData(candidatesData);
        }

        private UserData toUserData(User user)
        {
            return new UserData(
                user.Id.Value,
                user.Name.Value
            );
        }
    }
}
