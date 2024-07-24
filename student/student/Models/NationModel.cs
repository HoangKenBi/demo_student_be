using System.ComponentModel.DataAnnotations;

namespace student.Models
{
    public class NationModel
    {
        [Required]
        [MaxLength(50)]
        public string? NameNation { get; set; }
        [Required]
        [MaxLength(100)]
        public string? TitleNation { get; set; }
    }
    public class NationModelView
    {
        public int IdNation { get; set; }
        [Required]
        [MaxLength(50)]
        public string? NameNation { get; set; }
        [Required]
        [MaxLength(100)]
        public string? TitleNation { get; set; }
    }
}
