using System.Linq;
using SnsApplicationPort.Users.Commons;
using SnsApplicationPort.Users.GetAll;
using SnsDomain.Models.Users;

namespace SnsApplication.Users.Interactors
{
    public class UserGetAllInteractor : IUserGetAllInputPort
    {
        private readonly IUserRepository userRepository;

        public UserGetAllInteractor(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public UserGetAllOutputData Handle(UserGetAllInputData inputData)
        {
            var users = userRepository.FindAll();
            var userModels = users.Select(ToUserData).ToList();
            return new UserGetAllOutputData(userModels);
        }

        private UserData ToUserData(User user)
        {
            return new UserData(
                user.Id.Value,
                user.Name.Value
            );
        }
    }
}
