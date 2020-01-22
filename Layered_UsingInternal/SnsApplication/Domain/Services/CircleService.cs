using SnsApplication.Domain.Models.Circles;

namespace SnsApplication.Domain.Services
{
    public class CircleService
    {
        private readonly ICircleRepository circleRepository;

        public CircleService(ICircleRepository circleRepository)
        {
            this.circleRepository = circleRepository;
        }

        internal bool Exists(Circle circle)
        {
            var target = circleRepository.Find(circle.Name);
            return target != null;
        }
    }
}
