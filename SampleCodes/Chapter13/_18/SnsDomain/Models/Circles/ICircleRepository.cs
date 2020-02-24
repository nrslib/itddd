using System.Collections.Generic;
using _18.SnsDomain.Library.Specifications;

namespace _18.SnsDomain.Models.Circles
{
    public interface ICircleRepository
    {
        void Save(Circle circle);
        Circle Find(CircleId id);
        Circle Find(CircleName name);
        List<Circle> Find(ISpecification<Circle> specification);
        List<Circle> FindAll();
    }
}
