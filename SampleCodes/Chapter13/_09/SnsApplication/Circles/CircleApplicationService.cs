using _09.SnsApplication.Circles.Join;
using _09.SnsApplication.Users;
using _09.SnsDomain.Models.CircleMembers;
using _09.SnsDomain.Models.Circles;
using _09.SnsDomain.Models.Users;

namespace _09.SnsApplication.Circles
{
    public class CircleApplicationService
    {
        private readonly ICircleFactory circleFactory;
        private readonly ICircleRepository circleRepository;
        private readonly CircleService circleService;
        private readonly IUserRepository userRepository;

        public CircleApplicationService(
            ICircleFactory circleFactory,
            ICircleRepository circleRepository,
            CircleService circleService,
            IUserRepository userRepository)
        {
            this.circleFactory = circleFactory;
            this.circleRepository = circleRepository;
            this.circleService = circleService;
            this.userRepository = userRepository;
        }

        public void Join(CircleJoinCommand command)
        {
            var circleId = new CircleId(command.CircleId);
            var circle = circleRepository.Find(circleId);

            var owner = userRepository.Find(circle.Owner);
            var members = userRepository.Find(circle.Members);
            var circleMembers = new CircleMembers(circle.Id, owner, members);
            var circleFullSpec = new CircleMembersFullSpecification();
            if (circleFullSpec.IsSatisfiedBy(circleMembers))
            {
                throw new CircleFullException(circleId);
            }

            var memberId = new UserId(command.UserId);
            var member = userRepository.Find(memberId);
            if (member == null)
            {
                throw new UserNotFoundException(memberId, "ユーザが見つかりませんでした。");
            }

            circle.Join(member);
            circleRepository.Save(circle);
        }
    }
}
