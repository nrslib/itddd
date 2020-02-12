namespace _19
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new InMemoryUserRepository();
            var userService = new UserService(repository);
            var userApplicationService = new UserApplicationService(repository, userService);
            
            var id = "test-id";
            var user = new User(new UserId(id), new UserName("test-user"));
            repository.Save(user);

            // ユーザ名変更だけを行うように
            var updateNameCommand = new UserUpdateCommand(id)
            {
                Name = "naruse"
            };
            userApplicationService.Update(updateNameCommand);

            // メールアドレス変更だけを行うように
            var updateMailAddressCommand = new UserUpdateCommand(id)
            {
                MailAddress = "xxxx@example.com"
            };
            userApplicationService.Update(updateMailAddressCommand);
        }
    }
}
