using System;

namespace _31
{
    class Money
    {
        private readonly decimal amount;
        private readonly string currency;

        public Money(decimal amount, string currency)
        {
            if (currency == null) throw new ArgumentNullException(nameof(currency));

            this.amount = amount;
            this.currency = currency;
        }

        public Money Add(Money arg)
        {
            if (arg == null) throw new ArgumentNullException(nameof(arg));
            if (currency != arg.currency) throw new ArgumentException($"通貨単位が異なります（this:{currency}, arg:{arg.currency}）");

            return new Money(amount + arg.amount, currency);
        }
    }
}
