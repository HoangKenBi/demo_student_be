using System.ComponentModel.DataAnnotations;

namespace student.Models
{
    public class WardModel
    {
        [Required]
        [MaxLength(50)]
        public string? NameWard { get; set; }
        [Required]
        [MaxLength(100)]
        public string? TitleWard { get; set; }

        public int? IdDistrict { get; set; }
    }
    public class WardModelView
    {
        public int IdWard { get; set; }
        [Required]
        [MaxLength(50)]
        public string? NameWard { get; set; }
        [Required]
        [MaxLength(100)]
        public string? TitleWard { get; set; }

        public string? NameDistrict { get; set; }
    }
}

