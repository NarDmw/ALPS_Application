using System.Data.Entity;

namespace ALPS_Application.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("SampleDatabase")
        {

        }

        public DbSet<USState> USStates { get; set; }

        public DbSet<Office> Offices { get; set; }

        public DbSet<Employee> Employees { get; set; }
    }
}