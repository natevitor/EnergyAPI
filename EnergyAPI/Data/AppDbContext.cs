using Microsoft.EntityFrameworkCore;
using EnergyAPI.Models;

namespace EnergyAPI.Data {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) {
        }

        public DbSet<Device> Devices { get; set; } = null!; // Marcação para não ser nulo
        public DbSet<EnergyUsage> EnergyUsages { get; set; } = null!; // Marcação para não ser nulo
        public DbSet<Recommendation> Recommendations { get; set; } = null!; // Marcação para não ser nulo
    }
}
