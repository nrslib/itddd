using System.Transactions;
using _10.SnsApplication.Circles.Create;
using _10.SnsApplication.Circles.Join;
using _10.SnsApplication.Users;
using _10.SnsDomain.Models.Circles;
using _10.SnsDomain.Models.Users;

namespace _10.SnsApplication.Circles
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

        public void Create(CircleCreateCommand command)
        {
            using (var transaction = new TransactionScope())
            {
                var ownerId = new UserId(command.UserId);
                var owner = userRepository.Find(ownerId);
                if (owner == null)
                {
                    throw new UserNotFoundException(ownerId, "サークルのオーナーとなるユーザが見つかりませんでした。");
                }

                var name = new CircleName(command.Name);
                var circle = circleFactory.Create(name, owner);
                if (circleService.Exists(circle))
                {
                    throw new CanNotRegisterCircleException(circle, "サークルは既に存在しています。");
                }

                circleRepository.Save(circle);
                transaction.Complete();
            }
        }

        public void Join(CircleJoinCommand command)
        {
            using (var transaction = new TransactionScope())
            {
                var memberId = new UserId(command.UserId);
                var member = userRepository.Find(memberId);
                if (member == null)
                {
                    throw new UserNotFoundException(memberId, "ユーザが見つかりませんでした。");
                }

                var id = new CircleId(command.CircleId);
                var circle = circleRepository.Find(id);
                if (circle == null)
                {
                    throw new CircleNotFoundException(id, "サークルが見つかりませんでした。");
                }

                // サークルのオーナーを含めて３０名か確認
                if (circle.Members.Count >= 29)
                {
                    throw new CircleFullException(id);
                }

                // メンバーを追加する
                circle.Members.Add(member);
                circleRepository.Save(circle);
                transaction.Complete();
            }
        }
    }
}
