namespace _14.SnsDomain.Library.Specifications
{
    public interface ISpecification<T>
    {
        public bool IsSatisfiedBy(T value);
    }
}
