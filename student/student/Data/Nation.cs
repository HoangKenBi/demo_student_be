using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace student.Data
{
    [Table("Nation")]
    public class Nation
    {
        [Key]
        public int IdNation { get; set; }
        [Required]
        [MaxLength(50)]
        public string? NameNation { get; set; }
        [Required]
        [MaxLength(100)]
        public string? TitleNation { get; set; }

        public virtual ICollection<City>? Citys { get; set; }
        public virtual ICollection<Student>? Students { get; set; }

    }
}
