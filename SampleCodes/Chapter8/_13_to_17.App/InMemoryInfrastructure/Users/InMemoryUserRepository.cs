using System.Collections.Generic;
using System.Linq;
using _13_to_17.App.Models.Users;

namespace _13_to_17.App.InMemoryInfrastructure.Users
{
    public class InMemoryUserRepository : IUserRepository
    {
        public Dictionary<UserId, User> Store { get; } = new Dictionary<UserId, User>();

        public User Find(UserId id)
        {
            if (Store.TryGetValue(id, out var target))
            {
                return Clone(target);
            }
            else
            {
                return null;
            }
        }

        public User Find(UserName name)
        {
            foreach (var elem in Store.Values)
            {
                if (elem.Name.Equals(name))
                {
                    return Clone(elem);
                }
            }

            return null;
        }

        public List<User> FindAll()
        {
            return Store.Values.Select(Clone).ToList();
        }

        public void Save(User user)
        {
            Store[user.Id] = Clone(user);
        }

        public void Delete(User user)
        {
            if (Store.ContainsKey(user.Id))
            {
                Store.Remove(user.Id);
            }
        }

        private User Clone(User user)
        {
            return new User(user.Id, user.Name);
        }
    }
}