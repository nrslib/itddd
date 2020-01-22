using System.Collections.Generic;
using System.Linq;
using EFInfrastructure.Contexts;
using EFInfrastructure.Persistence.DataModels;
using Microsoft.EntityFrameworkCore;
using SnsApplication.Domain.Models.Circles;
using SnsApplication.Domain.Models.Users;

namespace EFInfrastructure.Persistence.Circles
{
    public class EFCircleRepository : ICircleRepository
    {
        private readonly ItdddDbContext context;

        public EFCircleRepository(ItdddDbContext context)
        {
            this.context = context;
        }

        private IEnumerable<CircleDataModel> circles => context
            .Circles
            .Include(x => x.CircleMembers)
            .ThenInclude(x => x.Circle);

        public Circle Find(CircleId id)
        {
            var target = circles.SingleOrDefault(x => x.Id == id.Value);
            if (target == null)
            {
                return null;
            }

            return ToModel(target);
        }

        public Circle Find(CircleName name)
        {
            var target = circles.FirstOrDefault(x => x.Name == name.Value);
            if (target == null)
            {
                return null;
            }

            return ToModel(target);
        }

        public List<Circle> FindAll()
        {
            return circles.Select(ToModel).ToList();
        }

        public void Save(Circle circle)
        {
            var found = circles.FirstOrDefault(x => x.Id == circle.Id.Value);

            if (found == null)
            {
                var data = ToDataModel(circle);
                context.Circles.Add(data);
            }
            else
            {
                var data = Transfer(circle, found);
                context.Circles.Update(data);
            }

            context.SaveChanges();
        }

        public void Delete(Circle circle)
        {
            var target = context.Circles.Find(circle.Id.Value);

            if (target == null)
            {
                return;
            }

            context.Circles.Remove(target);

            context.SaveChanges();
        }

        private Circle ToModel(CircleDataModel from)
        {
            return new Circle(
                new CircleId(from.Id),
                new CircleName(from.Name),
                from.OwnerId != null ? new UserId(from.OwnerId) : null,
                from.CircleMembers.Select(x => new UserId(x.UserId)).ToList()
            );
        }

        private CircleDataModel Transfer(Circle from, CircleDataModel model)
        {
            model.Name = from.Name.Value;
            model.OwnerId = from.Owner.Value;
            var currentMemberIds = model.CircleMembers.Select(cm => cm.UserId);
            var addMembers = from.Members
                .Where(x => !currentMemberIds.Contains(x.Value))
                .Select(x => context.Users.Find(x.Value));
            foreach (var member in addMembers)
            {
                model.CircleMembers.Add(new UserCircle
                {
                    CircleId = model.Id,
                    UserId = member.Id
                });
            }
            
            return model;
        }

        private CircleDataModel ToDataModel(Circle from)
        {
            return new CircleDataModel
            {
                Id = from.Id.Value,
                Name = from.Name.Value,
                Owner = context.Users.Find(from.Owner.Value),
                CircleMembers = from.Members
                    .Select(x => context.Users.Find(x.Value))
                    .Select(x => new UserCircle
                    {
                        UserId = x.Id,
                        User = x,
                        CircleId = from.Id.Value
                    })
                    .ToList()
            };
        }

    }
}
