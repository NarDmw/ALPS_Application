using ALPS_Test.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ALPS_Application.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("SampleDatabase")
        {

        }

        public DbSet<USState> USStates { get; set; }

    }
}