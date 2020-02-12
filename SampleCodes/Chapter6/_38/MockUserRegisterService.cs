namespace _38
{
    public class MockUserRegisterService : IUserRegisterService
    {
        public void Handle(UserRegisterCommand command)
        {
            throw new ComplexException();
        }
    }
}
