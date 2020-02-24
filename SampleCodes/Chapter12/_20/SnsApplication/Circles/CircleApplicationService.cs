using System.Transactions;
using _20.SnsApplication.Circles.Create;
using _20.SnsApplication.Circles.Join;
using _20.SnsApplication.Circles.Update;
using _20.SnsApplication.Users;
using _20.SnsDomain.Models.Circles;
using _20.SnsDomain.Models.Users;

namespace _20.SnsApplication.Circles
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

                if (circle.IsFull())
                {
                    throw new CircleFullException(id);
                }

                circle.Join(member);
                circleRepository.Save(circle);
                transaction.Complete();
            }
        }

        public void Update(CircleUpdateCommand command)
        {
            using (var transaction = new TransactionScope())
            {
                var id = new CircleId(command.Id);
                // この時点でUserのインスタンスが再構築されるが
                var circle = circleRepository.Find(id);
                if (circle == null)
                {
                    throw new CircleNotFoundException(id);
                }

                if (command.Name != null)
                {
                    var name = new CircleName(command.Name);
                    circle.ChangeName(name);
                    if (circleService.Exists(circle))
                    {
                        throw new CanNotRegisterCircleException(circle, "サークルは既に存在しています。");
                    }
                }

                circleRepository.Save(circle);

                transaction.Complete();

                // Userのインスタンスは使われることなく捨てられる
            }
        }
    }
}
