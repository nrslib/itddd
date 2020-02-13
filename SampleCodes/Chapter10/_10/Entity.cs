using System;
using System.Collections.Generic;
using System.Text;
using _09;

namespace _10
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
