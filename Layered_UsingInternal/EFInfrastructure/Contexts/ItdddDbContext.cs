using EFInfrastructure.Persistence.DataModels;
using Microsoft.EntityFrameworkCore;

namespace EFInfrastructure.Contexts
{
    public class ItdddDbContext : DbContext
    {
        public ItdddDbContext(DbContextOptions<ItdddDbContext> options) : base(options)
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
                .HasKey(x => new {x.UserId, x.CircleId});
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