using System;
using System.Collections.Generic;
using EFInfrastructure.Contexts;
using EFInfrastructure.Persistence.DataModels;
using EFInfrastructure.Persistence.Shared.Factory;
using Microsoft.EntityFrameworkCore;
using SnsDomain.Models.Circles;
using SnsDomain.Models.Users;

namespace EFInfrastructure.Persistence.Circles
{
    public class EFCircleFactory : SimpleIncrementalFactory<CircleDataModel>, ICircleFactory
    {
        public EFCircleFactory(ItdddDbContext context) : base(context)
        {
        }

        public Circle Create(CircleName name, User owner)
        {
            var id = AssignNumber();

            return new Circle(
                new CircleId(id),
                name,
                owner.Id,
                new List<UserId>()
            );
        }

        protected override int IdToInt(CircleDataModel data)
        {
            return Convert.ToInt32(data.Id);
        }

        protected override DbSet<CircleDataModel> GetDbSet(ItdddDbContext context)
        {
            return context.Circles;
        }
    }
}
