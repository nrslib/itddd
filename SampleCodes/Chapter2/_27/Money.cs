using System;

namespace _27
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
    }
}
