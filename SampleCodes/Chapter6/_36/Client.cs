namespace _36
{
    public class Client
    {
        private IUserRegisterService userRegisterService;

        public Client(IUserRegisterService userRegisterService)
        {
            this.userRegisterService = userRegisterService;
        }

        public void Register(string name)
        {
            var command = new UserRegisterCommand(name);
            userRegisterService.Handle(command);
        }
    }
}
