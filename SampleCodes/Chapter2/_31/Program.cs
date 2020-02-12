namespace _31
{
    class Program
    {
        static void Main(string[] args)
        {
            var jpy = new Money(1000, "JPY");
            var usd = new Money(10, "USD");

            var result = jpy.Add(usd); // 例外が送出される
        }
    }
}
