using System;
using System.Collections.Generic;
using System.Text;

namespace _09
{

    public class Some<T> : Option<T>
    {
        private readonly T val;

        public Some(T val)
        {
            this.val = val;
        }

        public override TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none = null)
        {
            return some(val);
        }

        public override void Match(Action<T> some, Action none = null)
        {
            some(val);
        }

        public override Option<TResult> Map<TResult>(Func<T, TResult> predicate)
        {
            return Option<TResult>.Create(predicate(val));
        }
    }
}
