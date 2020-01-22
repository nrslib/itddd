using InMemoryInfrastructure.Persistence.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnsApplication.Application.Users;
using SnsApplication.Application.Users.Register;
using SnsApplication.Domain.Models.Users;
using SnsApplication.Domain.Services;

namespace SnsApplication.Tests.Users
{
    [TestClass]
    public class UserRegisterTest
    {
        [TestMethod]
        public void TestSuccessMinUserName()
        {
            var userFactory = new InMemoryUserFactory();
            var userRepository = new InMemoryUserRepository();
            var userService = new UserService(userRepository);
            var userApplicationService = new UserApplicationService(userFactory, userRepository, userService);

            // 最短のユーザ名（３文字）のユーザが正常に生成できるか
            var userName = "123";
            var minUserNameInputData = new UserRegisterCommand(userName);
            var outputData = userApplicationService.Register(minUserNameInputData);
            Assert.IsNotNull(outputData.CreatedUserId);

            // ユーザが正しく保存されているか
            var createdUserName = new UserName(userName);
            var createdUser = userRepository.Find(createdUserName);
            Assert.IsNotNull(createdUser);
        }

        [TestMethod]
        public void TestSuccessMaxUserName()
        {
            var userFactory = new InMemoryUserFactory();
            var userRepository = new InMemoryUserRepository();
            var userService = new UserService(userRepository);
            var userApplicationService = new UserApplicationService(userFactory, userRepository, userService);

            // 最長のユーザ名（２０文字）のユーザが正常に生成できるか
            var userName = "12345678901234567890";
            var maxUserNameInputData = new UserRegisterCommand(userName);
            userApplicationService.Register(maxUserNameInputData);

            // ユーザが正しく保存されているか
            var createdUserName = new UserName(userName);
            var maxUserNameUser = userRepository.Find(createdUserName);
            Assert.IsNotNull(maxUserNameUser);
        }

        [TestMethod]
        public void TestInvalidUserNameLengthMin()
        {
            var userFactory = new InMemoryUserFactory();
            var userRepository = new InMemoryUserRepository();
            var userService = new UserService(userRepository);
            var userApplicationService = new UserApplicationService(userFactory, userRepository, userService);

            bool exceptionOccured = false;
            try
            {
                var command = new UserRegisterCommand("12");
                userApplicationService.Register(command);
            }
            catch
            {
                exceptionOccured = true;
            }

            Assert.IsTrue(exceptionOccured);
        }

        [TestMethod]
        public void TestInvalidUserNameLengthMax()
        {
            var userFactory = new InMemoryUserFactory();
            var userRepository = new InMemoryUserRepository();
            var userService = new UserService(userRepository);
            var userApplicationService = new UserApplicationService(userFactory, userRepository, userService);

            bool exceptionOccured = false;
            try
            {
                var command = new UserRegisterCommand("123456789012345678901");
                userApplicationService.Register(command);
            }
            catch
            {
                exceptionOccured = true;
            }

            Assert.IsTrue(exceptionOccured);
        }

        [TestMethod]
        public void TestAlreadyExists()
        {
            var userFactory = new InMemoryUserFactory();
            var userRepository = new InMemoryUserRepository();
            var userService = new UserService(userRepository);
            var userApplicationService = new UserApplicationService(userFactory, userRepository, userService);

            var userName = "test-user";
            userRepository.Save(new User(
                new UserId("test-id"),
                new UserName(userName),
                UserType.Normal
            ));

            bool exceptionOccured = false;
            try
            {
                var command = new UserRegisterCommand(userName);
                userApplicationService.Register(command);
            }
            catch
            {
                exceptionOccured = true;
            }

            Assert.IsTrue(exceptionOccured);
        }
    }
}
