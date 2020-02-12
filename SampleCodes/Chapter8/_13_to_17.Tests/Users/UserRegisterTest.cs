using System.Linq;
using _13_to_17.App.Application.Users;
using _13_to_17.App.Application.Users.Register;
using _13_to_17.App.InMemoryInfrastructure.Users;
using _13_to_17.App.Models.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _13_to_17.Tests.Users
{
    [TestClass]
    public class UserRegisterTest
    {
        [TestMethod]
        public void TestSuccessMinUserName()
        {
            var userRepository = new InMemoryUserRepository();
            var userService = new UserService(userRepository);
            var userApplicationService = new UserApplicationService(userRepository, userService);

            // 最短のユーザ名（３文字）のユーザが正常に生成できるか
            var userName = "123";
            var minUserNameInputData = new UserRegisterCommand(userName);
            userApplicationService.Register(minUserNameInputData);

            // ユーザが正しく保存されているか
            var createdUserName = new UserName(userName);
            var createdUser = userRepository.Find(createdUserName);
            Assert.IsNotNull(createdUser);
        }

        [TestMethod]
        public void TestSuccessMaxUserName()
        {
            var userRepository = new InMemoryUserRepository();
            var userService = new UserService(userRepository);
            var userApplicationService = new UserApplicationService(userRepository, userService);
            
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
        public void TestSuccessMinUserName_8_15()
        {
            var userRepository = new InMemoryUserRepository();
            var userService = new UserService(userRepository);
            var userApplicationService = new UserApplicationService(userRepository, userService);

            // 最短のユーザ名（３文字）のユーザが正常に生成できるか
            var userName = "123";
            var minUserNameInputData = new UserRegisterCommand(userName);
            userApplicationService.Register(minUserNameInputData);

            // ユーザが正しく保存されているか
            var createdUser = userRepository.Store.Values
                .FirstOrDefault(user => user.Name.Value == userName);
            Assert.IsNotNull(createdUser);
        }

        [TestMethod]
        public void TestInvalidUserNameLengthMin()
        {
            var userRepository = new InMemoryUserRepository();
            var userService = new UserService(userRepository);
            var userApplicationService = new UserApplicationService(userRepository, userService);

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
            var userRepository = new InMemoryUserRepository();
            var userService = new UserService(userRepository);
            var userApplicationService = new UserApplicationService(userRepository, userService);

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
            var userRepository = new InMemoryUserRepository();
            var userService = new UserService(userRepository);
            var userApplicationService = new UserApplicationService(userRepository, userService);

            var userName = "test-user";
            userRepository.Save(new User(
                new UserId("test-id"),
                new UserName(userName)
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
