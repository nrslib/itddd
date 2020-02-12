using System;
using System.Collections.Generic;
using System.Text;

namespace _09
{
    public abstract class Option<T>
    {
        public static Option<T> Create(T val)
        {
            return new Some<T>(val);
        }

        public static Option<T> None()
        {
            return new None<T>();
        }

        public abstract TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none = null);
        public abstract void Match(Action<T> some, Action none = null);
        public abstract Option<TResult> Map<TResult>(Func<T, TResult> predicate);
    }
}
