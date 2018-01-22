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
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "A real name please")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "A real name please")]
        public string LastName { get; set; }

        [Required]
        public virtual Office Office { get; set; }
        public string OfficeId { get; set; }

    }
}