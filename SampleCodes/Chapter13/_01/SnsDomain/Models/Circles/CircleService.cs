namespace _01.SnsDomain.Models.Circles
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
            var duplicated = circleRepository.Find(circle.Name);
            return duplicated != null;
        }
    }
}