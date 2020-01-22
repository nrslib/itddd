using System.Collections.Generic;
using System.Linq;
using InMemoryInfrastructure.Foundation.Repository;
using SnsDomain.Models.Users;

namespace InMemoryInfrastructure.Persistence.Users
{
    public class InMemoryUserRepository : InMemoryCrudRepository<UserId, User>, IUserRepository
    {
        protected override UserId GetKey(User value)
        {
            return value.Id;
        }

        protected override User DeepClone(User value)
        {
            return new User(
                value.Id,
                value.Name,
                value.Type
            );
        }

        public User Find(UserName name)
        {
            var target = Db.Values.FirstOrDefault(x => x.Name.Equals(name));
            if (target != null)
            {
                return DeepClone(target);
            }
            else
            {
                return null;
            }
        }

        public List<User> Find(IEnumerable<UserId> ids)
        {
            var targets = ids.ToHashSet();

            return Db.Values
                .Where(x => targets.Contains(x.Id))
                .Select(DeepClone)
                .ToList();
        }

        public List<User> FindAll()
        {
            return Db.Values
                .Select(DeepClone)
                .ToList();
        }
    }
}
