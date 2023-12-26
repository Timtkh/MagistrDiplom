using Microsoft.EntityFrameworkCore;

namespace WfDbApp
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=carsappdb;Trusted_Connection=True;");
        }
    }
}