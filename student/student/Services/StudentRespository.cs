using student.Data;
using student.Models;

namespace student.Services
{
    public class StudentRespository : IStudentRespository
    {
        private readonly MyDbContext _context;
        public static int PAGE_SIZE { get; set; } = 5;
        public StudentRespository(MyDbContext context)
        {
            _context = context;
        }
        public List<StudentModelView> GetAllStudent(string? search, string? sortBy, int page = 1)
        {
            var allStudent = _context.Students.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                allStudent = allStudent.Where(s => (s.NameStudent != null ? s.NameStudent : "").Contains(search));
            }

            allStudent = allStudent.OrderBy(s => s.NameStudent);
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "s_desc": allStudent = allStudent.OrderByDescending(s => s.NameStudent); break;
                    case "b_desc": allStudent = allStudent.OrderByDescending(s => s.BirthDayStudent); break;
                    case "b_asc": allStudent = allStudent.OrderBy(s => s.BirthDayStudent); break;
                }
            }

            allStudent = allStudent.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE);

            var result = allStudent.Select(s => new StudentModelView
            {
                IdStudent = s.IdStudent,
                NameStudent = s.NameStudent,
                PhoneStudent = s.PhoneStudent,
                EmailStudent = s.EmailStudent,
                BirthDayStudent = s.BirthDayStudent,
                NameNation = s.Nation != null ? s.Nation.NameNation: "",
                NameCity = s.City != null ? s.City.NameCity: "",
                NameDistrict = s.District != null ? s.District.NameDistrict: "",
                NameWard = s.Ward != null ? s.Ward.NameWard: ""
            });
            return result.ToList();
        }
    }
}
