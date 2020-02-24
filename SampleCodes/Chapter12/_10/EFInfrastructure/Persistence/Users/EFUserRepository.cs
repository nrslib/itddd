using System;
using System.Collections.Generic;
using _09.SnsDomain.Models.Users;
using _10.EFInfrastructure.Contexts;
using _10.EFInfrastructure.Persistence.DataModels;

namespace _10.EFInfrastructure.Persistence.Users
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
            // ゲッターを利用しデータの詰め替えをしている
            var userDataModel = new UserDataModel
            {
                Id = user.Id.Value,
                Name = user.Name.Value
            };
            context.Users.Add(userDataModel);
            context.SaveChanges();
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }
    }
}
