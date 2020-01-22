using System.Linq;
using SnsApplicationPort.Circles.Commons;
using SnsApplicationPort.Circles.GetAll;
using SnsDomain.Models.Circles;

namespace SnsApplication.Circles.Interactors
{
    public class CircleGetAllInteractor : ICIrcleGetAllInputPort
    {
        private readonly ICircleRepository circleRepository;

        public CircleGetAllInteractor(ICircleRepository circleRepository)
        {
            this.circleRepository = circleRepository;
        }

        public CircleGetAllOutputData Handle(CircleGetAllInputData request)
        {
            var circles = circleRepository.FindAll();
            var circleData = circles.Select(toCircleData).ToList();

            return new CircleGetAllOutputData(circleData);
        }

        private CircleData toCircleData(Circle circle)
        {
            return new CircleData(
                circle.Id.Value,
                circle.Name.Value,
                circle.Owner?.Value,
                circle.Members.Select(x => x.Value).ToList()
            );
        }
    }
}
