using CleverHiveDiary.Infrastructure.Data.Configuration;
using CleverHiveDiary.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleverHiveDiary.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new StatusConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new HiveConfiguration());
            builder.ApplyConfiguration(new FarmConfiguration());
            //builder.ApplyConfiguration(new RoleConfiguration());
            //builder.ApplyConfiguration(new UserRoleConfiguration());


            builder.Entity<ApplicationUser>()
           .HasMany(f => f.Notes)
           .WithOne(n => n.User)
           .HasForeignKey(n => n.UserId)
           .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ApplicationUser>()
           .HasOne(f => f.Farm)
           .WithOne(f => f.User)
           .HasForeignKey<Farm>(f => f.UserId);

            builder.Entity<Farm>()
           .HasMany(f => f.Hives)
           .WithOne(h => h.Farm)
           .HasForeignKey(h => h.FarmId)
            .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(builder);
        }

        public DbSet<ApplicationUser> Users { get; set; } = null!;

        public DbSet<Farm> Farms { get; set; } = null!;

        public DbSet<Hive> Hives { get; set; } = null!;

        public DbSet<Note> Notes { get; set; } = null!;

        //public DbSet<Role> Roles { get; set; } = null!;

        //public DbSet<UserRole> UserRoles { get; set; } = null!;

        public DbSet<StatusHive> statusHives { get; set; } = null!;
    }
}