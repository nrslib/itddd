using System.Linq;

namespace _18
{
    public class EFUserRepository : IUserRepository
    {
        private readonly MyDbContext context;

        public EFUserRepository(MyDbContext context)
        {
            this.context = context;
        }

        public User Find(UserName name)
        {
            var target = context.Users
                .FirstOrDefault(userData => userData.Name == name.Value);
            if (target == null)
            {
                return null;
            }
            return ToModel(target);
        }

        public void Save(User user)
        {
            var found = context.Users.Find(user.Id.Value);

            if (found == null)
            {
                var data = ToDataModel(user);
                context.Users.Add(data);
            }
            else
            {
                var data = Transfer(user, found);
                context.Users.Update(data);
            }

            context.SaveChanges();
        }

        private User ToModel(UserDataModel from)
        {
            return new User(
                new UserId(from.Id),
                new UserName(from.Name)
            );
        }

        private UserDataModel Transfer(User from, UserDataModel model)
        {
            model.Id = from.Id.Value;
            model.Name = from.Name.Value; return model;
        }

        private UserDataModel ToDataModel(User from)
        {
            return new UserDataModel
            {
                Id = from.Id.Value,
                Name = from.Name.Value,
            };
        }
    }
}
