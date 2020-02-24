using _20.EFInfrastructure.Persistence.DataModels;
using Microsoft.EntityFrameworkCore;

namespace _20.EFInfrastructure.Contexts
{
    public class MyDbContext : DbContext
    {
        public static DbContextOptionsBuilder OptionsBuilder
        {
            get
            {
                var contextOptionBuilder = new DbContextOptionsBuilder<MyDbContext>();
                var connectionString = "Server=(localdb)\\mssqllocaldb;Database=ItdddContext-1;Trusted_Connection=True;MultipleActiveResultSets=true";

                contextOptionBuilder.UseSqlServer(connectionString);

                return contextOptionBuilder;
            }
        }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public MyDbContext() : base(OptionsBuilder.Options)
        {
        }

        public DbSet<UserDataModel> Users { get; set; }

        public DbSet<CircleDataModel> Circles { get; set; }
        public DbSet<UserCircle> UserCircles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDataModel>()
                .HasMany(x => x.OwnedCircles)
                .WithOne(x => x.Owner)
                .HasForeignKey(x => x.OwnerId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<UserCircle>()
                .HasKey(x => new { x.UserId, x.CircleId });
            modelBuilder.Entity<UserCircle>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.MemberOf)
                .HasForeignKey(uc => uc.UserId);
            modelBuilder.Entity<UserCircle>()
                .HasOne(uc => uc.Circle)
                .WithMany(c => c.CircleMembers)
                .HasForeignKey(uc => uc.CircleId);
        }
    }
}
