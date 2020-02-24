using System;
using System.Linq;
using _16.SnsApplication.Circles.GetRecommend;
using _16.SnsDomain.Models.Circles;
using _16.SnsDomain.Models.Users;

namespace _16.SnsApplication.Circles
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
            var circleRecommendSpecification = new CircleRecommendSpecification(now);
            // リポジトリに仕様を引き渡して抽出（フィルタリング）
            var recommendCircles = circleRepository.Find(circleRecommendSpecification)
                .Take(10)
                .ToList();

            return new CircleGetRecommendResult(recommendCircles);
        }
    }
}
