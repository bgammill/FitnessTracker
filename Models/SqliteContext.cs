using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Models
{
    public class SqliteContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        // TODO Rename to WeightLogEntries
        public DbSet<WeightLogEntry> Weights { get; set; }

        public DbSet<FoodLogEntry> FoodLogEntries { get; set; }

        public DbSet<Food> Foods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=blogging.db");
        }
    }
}
