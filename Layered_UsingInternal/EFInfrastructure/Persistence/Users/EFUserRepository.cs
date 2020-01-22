using System.Collections.Generic;
using System.Linq;
using EFInfrastructure.Contexts;
using EFInfrastructure.Persistence.DataModels;
using SnsApplication.Domain.Models.Users;

namespace EFInfrastructure.Persistence.Users
{
    public class EFUserRepository : IUserRepository
    {
        private readonly ItdddDbContext context;

        public EFUserRepository(ItdddDbContext context)
        {
            this.context = context;
        }

        public User Find(UserId id)
        {
            var target = context.Users.Find(id.Value);
            if (target == null)
            {
                return null;
            }

            return ToModel(target);
        }

        public List<User> Find(IEnumerable<UserId> ids)
        {
            var rawIds = ids.Select(x => x.Value);

            var targets = context.Users
                .Where(userData => rawIds.Contains(userData.Id));

            return targets.Select(ToModel).ToList();
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

        public List<User> FindAll()
        {
            return context.Users.Select(ToModel).ToList();
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

        public void Delete(User user)
        {
            var target = context.Users.Find(user.Id.Value);

            if (target == null)
            {
                return;
            }

            context.Users.Remove(target);

            context.SaveChanges();
        }

        private User ToModel(UserDataModel from)
        {
            return new User(
                new UserId(from.Id),
                new UserName(from.Name),
                ToUserType(from.Type)
            );
        }

        private UserDataModel Transfer(User from, UserDataModel model)
        {
            model.Id = from.Id.Value;
            model.Name = from.Name.Value;
            model.Type = (int)from.Type;

            return model;
        }

        private UserDataModel ToDataModel(User from)
        {
            return new UserDataModel
            {
                Id = from.Id.Value,
                Name = from.Name.Value,
                Type = ToUserTypeInt(from.Type),
            };
        }

        private UserType ToUserType(int value)
        {
            return (UserType)value;
        }

        private int ToUserTypeInt(UserType type)
        {
            return (int)type;
        }
    }
}
