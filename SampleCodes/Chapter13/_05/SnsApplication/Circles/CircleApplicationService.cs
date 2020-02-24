using System.Linq;
using _05.SnsApplication.Circles.Join;
using _05.SnsApplication.Users;
using _05.SnsDomain.Models.Circles;
using _05.SnsDomain.Models.Users;

namespace _05.SnsApplication.Circles
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

            var circleFullSpecification = new CircleFullSpecification(userRepository);
            if (circleFullSpecification.IsSatisfiedBy(circle))
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
