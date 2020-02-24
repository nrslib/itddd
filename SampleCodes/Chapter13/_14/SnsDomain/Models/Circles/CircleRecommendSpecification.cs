using System;
using _14.SnsDomain.Library.Specifications;

namespace _14.SnsDomain.Models.Circles
{
    public class CircleRecommendSpecification : ISpecification<Circle>
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
