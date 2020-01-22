using System.Transactions;
using SnsApplicationPort.Circles.Update;
using SnsDomain.Models.Circles;
using SnsDomain.Services;

namespace SnsApplication.Circles.Interactors
{
    public class CircleUpdateInteractor : ICircleUpdateInputPort
    {
        private readonly ICircleRepository circleRepository;
        private readonly CircleService circleService;

        public CircleUpdateInteractor(ICircleRepository circleRepository, CircleService circleService)
        {
            this.circleRepository = circleRepository;
            this.circleService = circleService;
        }
        
        public CircleUpdateOutputData Handle(CircleUpdateInputData inputData)
        {
            using var transaction = new TransactionScope();

            var id = new CircleId(inputData.Id);
            var circle = circleRepository.Find(id);
            if (circle == null)
            {
                throw new CircleNotFoundException(id);
            }

            if (inputData.Name != null)
            {
                var name = new CircleName(inputData.Name);
                circle.ChangeName(name);

                if (circleService.Exists(circle))
                {
                    throw new CanNotRegisterCircleException(circle, "サークルは既に存在しています。");
                }
            }

            circleRepository.Save(circle);

            transaction.Complete();

            return new CircleUpdateOutputData();
        }
    }
}
