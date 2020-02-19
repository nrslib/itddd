using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using _08.SnsApplication.Circles.Create;
using _08.SnsApplication.Users;
using _08.SnsDomain.Models.Circles;
using _08.SnsDomain.Models.Users;

namespace _08.SnsApplication.Circles
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
    }
}
