using System.Collections.Generic;

namespace _22.SnsDomain.Models.Circles
{
    public interface ICircleRepository
    {
        IEnumerable<Circle> FindAll();
    }
}
