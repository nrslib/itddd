using System;
using System.Transactions;
using SnsApplicationPort.Circles.Delete;
using SnsDomain.Models.Circles;

namespace SnsApplication.Circles.Interactors
{
    public class CircleDeleteInteractor : ICircleDeleteInputPort
    {
        private readonly ICircleRepository circleRepository;

        public CircleDeleteInteractor(ICircleRepository circleRepository)
        {
            this.circleRepository = circleRepository;
        }

        public CircleDeleteOutputData Handle(CircleDeleteInputData inputData)
        {
            using var transaction = new TransactionScope();

            var id = new CircleId(inputData.Id);
            var circle = circleRepository.Find(id);
            if (circle == null)
            {
                return new CircleDeleteOutputData();
            }

            circleRepository.Delete(circle);

            transaction.Complete();

            return new CircleDeleteOutputData();
        }
    }
}
