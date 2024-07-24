using System.ComponentModel.DataAnnotations;

namespace student.Models
{
    public class CityModel
    {
        [Required]
        [MaxLength(50)]
        public string? NameCity { get; set; }
        [Required]
        [MaxLength(100)]
        public string? TitleCity { get; set; }

        public int? IdNation { get; set; }
    }
    public class CityModelView
    {
        public int IdCity { get; set; }
        [Required]
        [MaxLength(50)]
        public string? NameCity { get; set; }
        [Required]
        [MaxLength(100)]
        public string? TitleCity { get; set; }

        public string? NameNation { get; set; }
    }
}
