using System.Transactions;
using SnsApplication.Users;
using SnsApplicationPort.Circles.Join;
using SnsDomain.Models.Circles;
using SnsDomain.Models.Users;

namespace SnsApplication.Circles.Interactors
{
    public class CircleJoinInteractor : ICircleJoinInputPort
    {
        private readonly ICircleRepository circleRepository;
        private readonly IUserRepository userRepository;

        public CircleJoinInteractor(ICircleRepository circleRepository, IUserRepository userRepository)
        {
            this.circleRepository = circleRepository;
            this.userRepository = userRepository;
        }

        public CircleJoinOutputData Handle(CircleJoinInputData inputData)
        {
            using var transaction = new TransactionScope();

            var memberId = new UserId(inputData.MemberId);
            var member = userRepository.Find(memberId);
            if (member == null)
            {
                throw new UserNotFoundException(memberId, "ユーザが見つかりませんでした。");
            }

            var id = new CircleId(inputData.CircleId);
            var circle = circleRepository.Find(id);
            if (circle == null)
            {
                throw new CircleNotFoundException(id, "サークルが見つかりませんでした。");
            }

            var fullSpec = new CircleFullSpecification(userRepository);
            if (fullSpec.IsSatisfiedBy(circle))
            {
                throw new CircleFullException(id, "サークルに所属しているメンバーが上限に達しています。");
            }

            circle.Join(member, fullSpec);
            circleRepository.Save(circle);

            transaction.Complete();

            return new CircleJoinOutputData();
        }
    }
}
