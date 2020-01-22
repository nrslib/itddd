using System.Linq;
using System.Transactions;
using SnsApplication.Circles.Commons;
using SnsApplication.Circles.Create;
using SnsApplication.Circles.Delete;
using SnsApplication.Circles.Get;
using SnsApplication.Circles.GetAll;
using SnsApplication.Circles.Join;
using SnsApplication.Circles.Update;
using SnsApplication.Users;
using SnsDomain.Models.Circles;
using SnsDomain.Models.Users;
using SnsDomain.Services;

namespace SnsApplication.Circles
{
    public class CircleApplicationService
    {
        private readonly ICircleFactory circleFactory;
        private readonly ICircleRepository circleRepository;
        private readonly IUserRepository userRepository;
        private readonly CircleService circleService;

        public CircleApplicationService(ICircleFactory circleFactory, ICircleRepository circleRepository, IUserRepository userRepository, CircleService circleService)
        {
            this.circleFactory = circleFactory;
            this.circleRepository = circleRepository;
            this.userRepository = userRepository;
            this.circleService = circleService;
        }

        public CircleGetResult Get(CircleGetCommand command)
        {
            var id = new CircleId(command.Id);
            var circle = circleRepository.Find(id);

            var data = new CircleData(circle);

            return new CircleGetResult(data);
        }

        public CircleGetAllResult GetAll()
        {
            var circles = circleRepository.FindAll();
            var circleData = circles.Select(x => new CircleData(x)).ToList();

            return new CircleGetAllResult(circleData);
        }

        public CircleCreateResult Create(CircleCreateCommand command)
        {
            using (var transaction = new TransactionScope())
            {
                var ownerId = new UserId(command.OwnerId);
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

                return new CircleCreateResult(circle.Id.Value);
            }
        }

        public void Update(CircleUpdateCommand command)
        {
            using (var transaction = new TransactionScope())
            {
                var id = new CircleId(command.Id);
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
            }
        }

        public void Join(CircleJoinCommand command)
        {
            using (var transaction = new TransactionScope())
            {
                var memberId = new UserId(command.MemberId);
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

                var fullSpec = new CircleFullSpecification(userRepository);
                if (fullSpec.IsSatisfiedBy(circle))
                {
                    throw new CircleFullException(id, "サークルに所属しているメンバーが上限に達しています。");
                }

                circle.Join(member, fullSpec);
                circleRepository.Save(circle);

                transaction.Complete();
            }
        }

        public void Delete(CircleDeleteCommand command)
        {
            using (var transaction = new TransactionScope())
            {
                var id = new CircleId(command.Id);
                var circle = circleRepository.Find(id);
                if (circle == null)
                {
                    return;
                }

                circleRepository.Delete(circle);

                transaction.Complete();
            }
        }
    }
}
