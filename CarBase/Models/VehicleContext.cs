using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarBase.Models
{
    public class VehicleContext : IdentityDbContext
    {

        public VehicleContext(DbContextOptions<VehicleContext> options)
           : base(options)
        { }
        public DbSet<Users>? Users { get; set; }
        public DbSet<vehicle>? vehicles { get; set; }
        public DbSet<make>? makes { get; set; }
        public DbSet<engine>? engines { get; set; }
        public DbSet<type>? types { get; set; }
        public DbSet<FavoriteVehicles>? FavoriteVehicles { get; set; }
        public DbSet<RentedVehicles>? RentedVehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RentedVehicles>()
                .HasKey(t => new { t.vehicleID, t.UsersID });

            modelBuilder.Entity<FavoriteVehicles>()
                .HasKey(t => new { t.vehicleID, t.UsersID });

            base.OnModelCreating(modelBuilder);
        }

    }

}
