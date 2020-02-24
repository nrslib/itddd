using System;
using System.Linq;
using _13.SnsApplication.Circles.GetRecommend;
using _13.SnsDomain.Models.Circles;
using _13.SnsDomain.Models.Users;

namespace _13.SnsApplication.Circles
{
    public class CircleApplicationService
    {
        private readonly ICircleFactory circleFactory;
        private readonly ICircleRepository circleRepository;
        private readonly CircleService circleService;
        private readonly IUserRepository userRepository;
        private readonly DateTime now;

        public CircleApplicationService(
            ICircleFactory circleFactory,
            ICircleRepository circleRepository,
            CircleService circleService,
            IUserRepository userRepository,
            DateTime now)
        {
            this.circleFactory = circleFactory;
            this.circleRepository = circleRepository;
            this.circleService = circleService;
            this.userRepository = userRepository;
            this.now = now;
        }

        public CircleGetRecommendResult GetRecommend(CircleGetRecommendRequest request)
        {
            var recommendCircleSpec = new CircleRecommendSpecification(now);
            var circles = circleRepository.FindAll();
            var recommendCircles = circles
                .Where(recommendCircleSpec.IsSatisfiedBy)
                .Take(10)
                .ToList();
            return new CircleGetRecommendResult(recommendCircles);
        }
    }
}
