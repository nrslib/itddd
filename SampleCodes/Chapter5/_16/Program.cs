namespace _16
{
    class Program
    {
        static void Main(string[] args)
        {
            var userRepository = new InMemoryUserRepository();

            var user = new User(new UserName("Naruse"));

            // ここでインスタンスをそのままリポジトリに保存してしまうと
            userRepository.Save(user);
            // インスタンスの操作がリポジトリに保存したインスタンスにまで影響する
            user.ChangeUserName(new UserName("naruse"));
        }
    }
}
