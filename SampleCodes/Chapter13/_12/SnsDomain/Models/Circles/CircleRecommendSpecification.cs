using System;

namespace _12.SnsDomain.Models.Circles
{
    public class CircleRecommendSpecification
    {
        private readonly DateTime executeDateTime;
        public CircleRecommendSpecification(DateTime executeDateTime)
        {
            this.executeDateTime = executeDateTime;
        }

        public bool IsSatisfiedBy(Circle circle)
        {
            if (circle.CountMembers() < 10)
            {
                return false;
            }
            return circle.Created > executeDateTime.AddMonths(-1);
        }
    }
}
