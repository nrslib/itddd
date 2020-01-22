using System.Collections.Generic;
using System.Linq;
using InMemoryInfrastructure.Foundation.Repository;
using SnsApplication.Domain.Models.Circles;

namespace InMemoryInfrastructure.Persistence.Circles
{
    public class InMemoryCircleRepository : InMemoryCrudRepository<CircleId, Circle>, ICircleRepository
    {
        protected override CircleId GetKey(Circle value)
        {
            return value.Id;
        }

        protected override Circle DeepClone(Circle value)
        {
            return new Circle(
                value.Id,
                value.Name,
                value.Owner,
                value.Members.ToList()
            );
        }

        public Circle Find(CircleName name)
        {
            var target = Db.Values.FirstOrDefault(x => x.Name.Equals(name));
            if (target != null)
            {
                return DeepClone(target);
            }
            else
            {
                return null;
            }
        }

        public List<Circle> FindAll()
        {
            return Db.Values
                .Select(DeepClone)
                .ToList();
        }
    }
}
