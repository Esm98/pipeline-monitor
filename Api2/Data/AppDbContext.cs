// Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using Api2.Models;

namespace Api2.Data
{
    // DbContext manages the connection to the database
    // and tracks which tables (DbSets) exist.
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        // Each DbSet corresponds to a table in the database.
        public DbSet<SensorReading> SensorReadings { get; set; }
    }
}
