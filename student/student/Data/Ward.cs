using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace student.Data
{
    [Table("Ward")]
    public class Ward
    {
        [Key]
        public int IdWard { get; set; }
        [Required]
        [MaxLength(50)]
        public string? NameWard { get; set; }
        [Required]
        [MaxLength(100)]
        public string? TitleWard { get; set; }

        public int? IdDistrict { get; set; }
        [ForeignKey("IdDistrict")]
        public District? District { get; set; }
        public virtual ICollection<Student>? Students { get; set; }

    }
}
