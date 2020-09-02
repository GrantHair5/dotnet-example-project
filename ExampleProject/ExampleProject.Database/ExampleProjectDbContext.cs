using Microsoft.EntityFrameworkCore;
using ExampleProject.Database.Models;

namespace ExampleProject.Database
{
    public class ExampleProjectDbContext : DbContext
    {
        public ExampleProjectDbContext(DbContextOptions<ExampleProjectDbContext> options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}