namespace _14
{
    // 処理の具体的な内容は主題ではないので省略
    class PhysicalDistributionBase
    {
        public Baggage Ship(Baggage baggage)
        {
            return baggage;
        }

        public void Receive(Baggage baggage)
        {
            // ...
        }

        public void Transport(PhysicalDistributionBase to, Baggage baggage)
        {
            var shippedBaggage = Ship(baggage);
            to.Receive(shippedBaggage);

            // たとえば配送の記録は必要だろうか
        }
    }
}
