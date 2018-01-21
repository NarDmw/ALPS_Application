using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ALPS_Test.Models
{
    public class USState
    {
        [Key]
        public int ID { get; set; }

        //Data Annotation
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(2)]
        public string Abbreviation { get; set; }
    }

    //public class USStateDBContext : DbContext
    //{
    //    public DbSet<USState> USStates { get; set; }
    //}
}