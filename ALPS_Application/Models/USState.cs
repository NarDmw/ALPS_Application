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
        //TODO: Figure out how to do uniqueness
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(2)]
        public string Abbreviation { get; set; }
    }
}