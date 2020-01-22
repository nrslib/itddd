using System.Linq;
using EFInfrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EFInfrastructure.Persistence.Shared.Factory
{
    public abstract class SimpleIncrementalFactory <TDataModel> where TDataModel : class
    {
        private readonly ItdddDbContext context;

        protected SimpleIncrementalFactory(ItdddDbContext context)
        {
            this.context = context;
        }

        protected abstract int IdToInt(TDataModel data);

        protected abstract DbSet<TDataModel> GetDbSet(ItdddDbContext context);

        protected string AssignNumber()
        {
            var dbSet = GetDbSet(context);

            if (!dbSet.Any())
            {
                return "1";
            }

            var max = dbSet.Select(IdToInt).Max();
            var id = max + 1;

            return id.ToString();
        }
    }
}
