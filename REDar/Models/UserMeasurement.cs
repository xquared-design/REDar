using REDar.Areas.Identity.Data;
using REDar.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace REDar.Models
{
    public class UserMeasurement
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; }

        public REDarUser User { get; set; }

        [Required]
        public MeasType type { get; set; }
        [Display(Name = "Measurment Value")]
        public float? val { get; set; }



        
        [Required]
        public DateTime TimeStamp { get; set; }
    }
}
