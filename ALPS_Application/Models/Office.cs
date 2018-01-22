using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ALPS_Application.Models
{
    public class Office
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Column(TypeName ="varchar")]
        [RegularExpression(@"^[a-zA-Z]+[\s-]?[a-zA-Z]*$", ErrorMessage = "A real cityname please")]
        public string City { get; set; }

        [Required]
        public virtual USState State { get; set; }
        public string USStateId { get; set; }
    }
}