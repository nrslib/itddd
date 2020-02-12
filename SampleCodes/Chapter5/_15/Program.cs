namespace _15
{
    class Program
    {
        static void Main(string[] args)
        {
            var userRepository = new InMemoryUserRepository();

            // オブジェクトを再構築する際にディープコピーを行わないと
            var user = userRepository.Find(new UserName("Naruse"));
            // 次の操作がリポジトリ内部で保管されているインスタンスにまで影響する
            user.ChangeUserName(new UserName("naruse"));
        }
    }
}
