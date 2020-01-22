using System;
using EFInfrastructure.Contexts;
using EFInfrastructure.Persistence.DataModels;
using EFInfrastructure.Persistence.Shared.Factory;
using Microsoft.EntityFrameworkCore;
using SnsApplication.Domain.Models.Users;

namespace EFInfrastructure.Persistence.Users
{
    public class EFUserFactory : SimpleIncrementalFactory<UserDataModel>, IUserFactory
    {
        public EFUserFactory(ItdddDbContext context) : base(context)
        {
        }

        public User Create(UserName name)
        {
            var id = AssignNumber();

            return new User(
                new UserId(id),
                name,
                UserType.Normal
            );
        }

        protected override int IdToInt(UserDataModel data)
        {
            return Convert.ToInt32(data.Id);
        }

        protected override DbSet<UserDataModel> GetDbSet(ItdddDbContext context)
        {
            return context.Users;
        }
    }
}