namespace _12.Domain.Shared
{
    public abstract class Entity
    {
        protected void MarkNew()
        {
            UnitOfWork.Current.RegisterNew(this);
        }
        protected void MarkClean()
        {
            UnitOfWork.Current.RegisterClean(this);
        }
        protected void MarkDirty()
        {
            UnitOfWork.Current.RegisterDirty(this);
        }
        protected void MarkDeleted()
        {
            UnitOfWork.Current.RegisterDeleted(this);
        }
    }
}
