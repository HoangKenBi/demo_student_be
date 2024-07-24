using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace student.Data
{
    [Table("City")]
    public class City
    {
        [Key]
        public int IdCity { get; set; }
        [Required]
        [MaxLength(50)]
        public string? NameCity { get; set; }
        [Required]
        [MaxLength(100)]
        public string? TitleCity { get; set; }

        public int? IdNation { get; set; }
        [ForeignKey("IdNation")]
        public Nation? Nation { get; set; }

        public virtual ICollection<District>? Districts { get; set; }
        public virtual ICollection<Student>? Students { get; set; }

    }
}
