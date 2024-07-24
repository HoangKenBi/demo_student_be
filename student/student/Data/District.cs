using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace student.Data
{
    [Table("District")]
    public class District
    {
        [Key]
        public int IdDistrict { get; set; }
        [Required]
        [MaxLength(50)]
        public string? NameDistrict { get; set; }
        [Required]
        [MaxLength(100)]
        public string? TitleDistrict { get; set; }

        public int? IdCity { get; set; }
        [ForeignKey("IdCity")]
        public City? City { get; set; }

        public virtual ICollection<Ward>? Wards { get; set; }
        public virtual ICollection<Student>? Students { get; set; }

    }
}
