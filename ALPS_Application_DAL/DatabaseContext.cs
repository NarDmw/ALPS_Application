using System.Data.Entity;

namespace ALPS_Application.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\NarDmw\source\repos\ALPS_Application\ALPS_Application\App_Data\SampleDatabase.mdf;Integrated Security=True")
        {

        }

        public DbSet<USState> USStates { get; set; }

        public DbSet<Office> Offices { get; set; }

        public DbSet<Employee> Employees { get; set; }
    }
}