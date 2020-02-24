namespace _14.SnsDomain.Models.Circles
{
    public interface ICircleRepository
    {
        public void Save(Circle circle);
        public Circle Find(CircleId id);
        public Circle Find(CircleName name);
    }
}
