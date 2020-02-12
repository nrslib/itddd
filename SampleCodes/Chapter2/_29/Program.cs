namespace _29
{
    class Program
    {
        static void Main(string[] args)
        {
            var myMoney = new Money(1000, "JPY");
            var allowance = new Money(3000, "JPY");
            var result = myMoney.Add(allowance);
        }
    }
}
