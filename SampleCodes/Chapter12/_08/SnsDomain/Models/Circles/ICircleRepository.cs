namespace _08.SnsDomain.Models.Circles
{
    public interface ICircleRepository
    {
        void Save(Circle circle);
        Circle Find(CircleId id);
        Circle Find(CircleName name);
    }
}
