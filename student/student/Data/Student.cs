using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace student.Data
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int IdStudent { get; set; }
        [Required]
        [MaxLength(100)]
        public string? NameStudent { get; set; }
        [Required]
        [MaxLength(50)]
        public string? PhoneStudent { get; set; }
        [Required]
        [MaxLength(50)]
        public string? EmailStudent { get; set; }
        [Required]
        public DateTime? BirthDayStudent { get; set; }

        public int IdNation { get; set; }
        [ForeignKey("IdNation")]
        public Nation? Nation { get; set; }

        public int IdCity { get; set; }
        [ForeignKey("IdCity")]
        public City? City { get; set; }

        public int IdDistrict { get; set; }
        [ForeignKey("IdDistrict")]
        public District? District { get; set; }

        public int IdWard { get; set; }
        [ForeignKey("IdWard")]
        public Ward? Ward { get; set; }
    }
}
