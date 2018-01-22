using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ALPS_Application.Models
{
    public class USState
    {
        [Key]
        public int ID { get; set; }

        //Data Annotation
        //TODO: Figure out how to do uniqueness
        [Required]
        [Column(TypeName = "varchar")]
        [RegularExpression(@"[a-zA-z\s]+", ErrorMessage = "Invalid State Name")]
        [Display(Name = "State Name")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(2, MinimumLength = 2)]
        public string Abbreviation { get; set; }
    }
}