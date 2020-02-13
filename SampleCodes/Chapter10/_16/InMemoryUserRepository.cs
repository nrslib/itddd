using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _16.Domain.Models.Users;

namespace _16
{
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly Dictionary<string, User> creates = new Dictionary<string, User>();
        private readonly Dictionary<string, User> updates = new Dictionary<string, User>();
        private readonly Dictionary<string, User> deletes = new Dictionary<string, User>();
        private Dictionary<string, User> db = new Dictionary<string, User>();

        private Dictionary<string, User> data => db
            .Except(deletes)
            .Concat(creates)
            .Concat(updates)
            .ToDictionary(x => x.Key, x => x.Value);

        public List<User> FindAll()
        {
            return data.Values.Select(Clone).ToList();
        }

        public void Save(User user)
        {
            var rawUserId = user.Id.Value;
            var targetMap = data.ContainsKey(rawUserId) ? updates : creates;
            targetMap[rawUserId] = Clone(user);
        }

        public void Remove(User user)
        {
            deletes[user.Name.Value] = Clone(user);
        }

        public void Commit()
        {
            db = data;
            creates.Clear();
            updates.Clear();
            deletes.Clear();
        }

        private User Clone(User user)
        {
            return new User(user.Id, user.Name);
        }

        public User Find(UserId id)
        {
            if (data.TryGetValue(id.Value, out var target))
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
            var target = data.Values.FirstOrDefault(x => x.Name.Equals(name));
            if (target != null)
            {
                return Clone(target);
            }
            else
            {
                return null;
            }
        }

        public void Delete(User user)
        {
            Remove(user);
        }
    }

}
