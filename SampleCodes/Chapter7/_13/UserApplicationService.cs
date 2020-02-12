namespace _13
{
    public class UserApplicationService
    {
        private readonly IUserRepository userRepository;
        // 新たなフィールドが追加された
        private readonly IFooRepository fooRepository;

        public UserApplicationService()
        {
            this.userRepository = ServiceLocator.Resolve<IUserRepository>();
            // ServiceLocator経由で取得している
            this.fooRepository = ServiceLocator.Resolve<IFooRepository>();
        }

        public UserData Get(string userId)
        {
            var targetId = new UserId(userId);
            var user = userRepository.Find(targetId);

            if (user == null)
            {
                return null;
            }

            var userData = new UserData(user);
            return userData;
        }
    }
}
