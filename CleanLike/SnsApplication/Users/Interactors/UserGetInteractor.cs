using SnsApplicationPort.Users.Commons;
using SnsApplicationPort.Users.Get;
using SnsDomain.Models.Users;

namespace SnsApplication.Users.Interactors
{
    public class UserGetInteractor : IUserGetInputPort
    {
        private readonly IUserRepository userRepository;

        public UserGetInteractor(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public UserGetOutputData Handle(UserGetInputData inputData)
        {
            var id = new UserId(inputData.Id);
            var user = userRepository.Find(id);
            if (user == null)
            {
                throw new UserNotFoundException(id, "ユーザが見つかりませんでした。");
            }

            var data = new UserData(user.Id.Value, user.Name.Value);

            return new UserGetOutputData(data);
        }
    }
}
