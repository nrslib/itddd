using System.Collections.Generic;

namespace _13
{
    class InMemoryUserRepository : IUserRepository
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