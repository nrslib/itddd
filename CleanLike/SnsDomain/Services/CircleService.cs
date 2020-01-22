using SnsDomain.Models.Circles;

namespace SnsDomain.Services
{
    public class CircleService
    {
        private readonly ICircleRepository circleRepository;

        public CircleService(ICircleRepository circleRepository)
        {
            this.circleRepository = circleRepository;
        }

        public bool Exists(Circle circle)
        {
            var target = circleRepository.Find(circle.Name);
            return target != null;
        }
    }
}
