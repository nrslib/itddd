using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace _18
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
    }
}
