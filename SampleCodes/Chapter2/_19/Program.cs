namespace _19
{
    class Program
    {
        static void Main(string[] args)
        {
            var nameA = new FullName("masanobu", "", "naruse");
            var nameB = new FullName("masanobu", "", "naruse");
            var compareResult = nameA.FirstName == nameB.FirstName
                                && nameA.LastName == nameB.LastName
                                && nameA.MiddleName == nameB.MiddleName // 条件式を追加
                ;
        }
    }
}
