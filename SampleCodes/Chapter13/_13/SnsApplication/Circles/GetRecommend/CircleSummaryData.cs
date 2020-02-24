using _13.SnsDomain.Models.Circles;

namespace _13.SnsApplication.Circles.GetRecommend
{
    public class CircleSummaryData
    {
        public CircleSummaryData(Circle circle)
        {
            Id = circle.Id.ToString();
            Name = circle.Name.ToString();
        }

        public string Id { get; }
        public string Name { get; }
    }
}
