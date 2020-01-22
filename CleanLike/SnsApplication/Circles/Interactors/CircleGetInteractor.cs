using System.Linq;
using SnsApplicationPort.Circles.Commons;
using SnsApplicationPort.Circles.Get;
using SnsDomain.Models.Circles;

namespace SnsApplication.Circles.Interactors
{
    public class CircleGetInteractor : ICIrcleGetInputPort
    {
        private readonly ICircleRepository circleRepository;

        public CircleGetInteractor(ICircleRepository circleRepository)
        {
            this.circleRepository = circleRepository;
        }

        public CircleGetOutputData Handle(CircleGetInputData inputData)
        {
            var id = new CircleId(inputData.Id);
            var circle = circleRepository.Find(id);

            var data = new CircleData(
                circle.Id.Value,
                circle.Name.Value,
                circle.Owner?.Value,
                circle.Members.Select(x => x.Value).ToList()
            );

            return new CircleGetOutputData(data);
        }
    }
}
