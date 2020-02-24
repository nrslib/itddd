using System.Collections.Generic;

namespace _20.SnsDomain.Models.Circles
{
    public interface ICircleRepository
    {
        IEnumerable<Circle> FindAll();
    }
}
