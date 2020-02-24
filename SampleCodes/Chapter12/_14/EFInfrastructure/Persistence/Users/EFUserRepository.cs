using System;
using System.Collections.Generic;
using _14.EFInfrastructure.Contexts;
using _14.SnsDomain.Models.Users;

namespace _14.EFInfrastructure.Persistence.Users
{
    public class EFUserRepository : IUserRepository
    {
        private readonly MyDbContext context;

        public EFUserRepository(MyDbContext context)
        {
            this.context = context;
        }

        public User Find(UserId id)
        {
            throw new NotImplementedException();
        }

        public User Find(UserName name)
        {
            throw new NotImplementedException();
        }

        public List<User> FindAll()
        {
            throw new NotImplementedException();
        }

        public void Save(User user)
        {
            // 通知オブジェクトを引き渡しダブルディスパッチにより内部データを取得
            var userDataModelBuilder = new UserDataModelBuilder();
            user.Notify(userDataModelBuilder);

            // 通知された内部データからデータモデルを生成
            var userDataModel = userDataModelBuilder.Build();

            // データモデルをO/R Mapperに引き渡す
            context.Users.Add(userDataModel);
            context.SaveChanges();
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }
    }
}
