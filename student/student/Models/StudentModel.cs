using System.ComponentModel.DataAnnotations;

namespace student.Models
{
    public class StudentModel
    {
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
        public int IdCity { get; set; }
        public int IdDistrict { get; set; }
        public int IdWard { get; set; }
    }
    public class StudentModelView
    {
        public int IdStudent { get; set; }
        public string? NameStudent { get; set; }
        public string? PhoneStudent { get; set; }
        public string? EmailStudent { get; set; }
        public DateTime? BirthDayStudent { get; set; }
        public string? NameNation { get; set; }
        public string? NameCity { get; set; }
        public string? NameDistrict { get; set; }
        public string? NameWard { get; set; }
    }
   
}
