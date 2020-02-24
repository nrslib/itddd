using System.Configuration;
using _12.EFInfrastructure.Persistence.DataModels;
using Microsoft.EntityFrameworkCore;

namespace _12.EFInfrastructure.Contexts
{
    public class MyDbContext : DbContext
    {
        public static MyDbContext Create()
        {
            var builder = new DbContextOptionsBuilder<MyDbContext>();
            builder.UseSqlServer(ConfigurationManager.ConnectionStrings["FooConnection"].ConnectionString);
            var options = builder.Options;
            var context = new MyDbContext(options);

            return context;
        }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<UserDataModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
