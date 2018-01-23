using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ALPS_Application.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [Display(Name="First Name")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "A real name please")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [Display(Name="Last Name")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "A real name please")]
        public string LastName { get; set; }

        [Required]
        [Display(Name="Office Location")]
        public int OfficeId { get; set; }
        public virtual Office Office { get; set; }

    }
}