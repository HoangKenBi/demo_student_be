using student.Data;
using student.Models;

namespace student.Services
{
    public class DistrictRespository : IDistrictRespository
    {
        private readonly MyDbContext _context;
        public static int PAGE_SIZE { get; set; } = 5;

        public DistrictRespository(MyDbContext context)
        {
            _context = context;
        }

        public List<DistrictModelView> GetAllDistrict(string? search, string? sortBy, int page = 1)
        {
            var allStudent = _context.Districts.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                allStudent = allStudent.Where(d => (d.NameDistrict != null ? d.NameDistrict : "").Contains(search));
            }

            allStudent = allStudent.OrderBy(d => d.NameDistrict);
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "d_desc": allStudent = allStudent.OrderByDescending(d => d.NameDistrict); break;
                }
            }

            allStudent = allStudent.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE);
            var result = allStudent.Select(d => new DistrictModelView
            {
                IdDistrict = d.IdDistrict,
                NameDistrict = d.NameDistrict,
                TitleDistrict = d.TitleDistrict,
                NameCity = d.City != null ? d.City.NameCity: "" 
            });
            return result.ToList();
        }
    }
}
