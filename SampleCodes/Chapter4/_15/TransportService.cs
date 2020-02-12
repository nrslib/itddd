namespace _15
{
    class TransportService
    {
        public void Transport(PhysicalDistributionBase from, PhysicalDistributionBase to, Baggage baggage)
        {
            var shippedBaggage = from.Ship(baggage);
            to.Receive(shippedBaggage);

            // 配送の記録を行う
        }
    }
}
