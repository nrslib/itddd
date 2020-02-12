using System;
using System.Collections.Generic;
using System.Text;

namespace _09
{

    public class None<T> : Option<T>
    {
        public override TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none = null)
        {
            if (none == null)
            {
                throw new ArgumentNullException();
            }

            return none();
        }

        public override void Match(Action<T> some, Action none = null)
        {
            none?.Invoke();
        }

        public override Option<TResult> Map<TResult>(Func<T, TResult> predicate)
        {
            return Option<TResult>.None();
        }
    }
}
