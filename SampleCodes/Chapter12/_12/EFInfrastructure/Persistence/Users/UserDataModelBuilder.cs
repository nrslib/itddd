using _12.EFInfrastructure.Persistence.DataModels;
using _12.SnsDomain.Models.Users;

namespace _12.EFInfrastructure.Persistence.Users
{
    public class UserDataModelBuilder : IUserNotification
    {
        // 通知されたデータはインスタンス変数で保持される
        private UserId id;
        private UserName name;
        public void Id(UserId id)
        {
            this.id = id;
        }
        public void Name(UserName name)
        {
            this.name = name;
        }
        // 通知されたデータからデータモデルを生成するメソッド
        public UserDataModel Build()
        {
            return new UserDataModel
            {
                Id = id.Value,
                Name = name.Value
            };
        }
    }
}
