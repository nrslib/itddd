namespace _43
{
    class Program
    {
        private User CreateUser(UserName name)
        {
            var user = new User();
            // user.Id = name; // コンパイルエラー！
            return user;
        }
    }
}
