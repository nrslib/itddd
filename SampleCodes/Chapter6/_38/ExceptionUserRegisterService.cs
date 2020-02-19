namespace _38
{
    public class ExceptionUserRegisterService : IUserRegisterService
    {
        public void Handle(UserRegisterCommand command)
        {
            throw new ComplexException();
        }
    }
}
