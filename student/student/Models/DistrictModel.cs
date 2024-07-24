using System.ComponentModel.DataAnnotations;

namespace student.Models
{
    public class DistrictModel
    {
        [Required]
        [MaxLength(50)]
        public string? NameDistrict { get; set; }
        [Required]
        [MaxLength(100)]
        public string? TitleDistrict { get; set; }

        public int? IdCity { get; set; }
    }
    public class DistrictModelView
    {
        public int IdDistrict { get; set; }
        [Required]
        [MaxLength(50)]
        public string? NameDistrict { get; set; }
        [Required]
        [MaxLength(100)]
        public string? TitleDistrict { get; set; }

        public string? NameCity { get; set; }
    }
}
