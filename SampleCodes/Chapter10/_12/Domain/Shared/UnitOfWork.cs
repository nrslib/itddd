using System;

namespace _12.Domain.Shared
{
    public class UnitOfWork
    {
        private static UnitOfWork _current;

        public static UnitOfWork Current = _current ??= new UnitOfWork();

        public void RegisterNew(object value)
        {
            throw new NotImplementedException();
        }

        public void RegisterDirty(object value)
        {
            throw new NotImplementedException();
        }

        public void RegisterClean(object value)
        {
            throw new NotImplementedException();
        }

        public void RegisterDeleted(object value)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }
    }
}
