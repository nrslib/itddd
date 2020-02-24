using System;
using System.Linq;
using _22.SnsApplication.Circles.GetSummaries;
using _22.SnsDomain.Models.Circles;
using _22.SnsDomain.Models.Users;

namespace _22.SnsApplication.Circles
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

        public CircleGetSummariesResult GetSummaries(CircleGetSummariesCommand command)
        {
            // この段階ではデータを取得しない
            var all = circleRepository.FindAll();
            // ページング処理は条件を付与しているに過ぎないためデータを取得しない
            var chunk = all
                .Skip((command.Page - 1) * command.Size)
                .Take(command.Size);
            // ここではじめてコレクションが処理されるため、条件に応じてデータ取得がされる
            var summaries = chunk
                .Select(x =>
                {
                    var owner = userRepository.Find(x.Owner);
                    return new CircleSummaryData(x.Id.Value, owner.Name.Value);
                })
                .ToList();
            return new CircleGetSummariesResult(summaries);
        }
    }
}
