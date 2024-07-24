using student.Data;
using student.Models;

namespace student.Services
{
    public class CityRespository : ICityRespository
    {
        private readonly MyDbContext _context;
        public static int PAGE_SIZE { get; set; } = 5;

        public CityRespository(MyDbContext context)
        {
            _context = context;
        }
        public List<CityModelView> GetAllCity(string? search, string? sortBy, int page = 1)
        {
            var allStudent = _context.Citys.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                allStudent = allStudent.Where(c => (c.NameCity != null ? c.NameCity : "").Contains(search));
            }

            allStudent = allStudent.OrderBy(c => c.NameCity);
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "c_desc": allStudent = allStudent.OrderByDescending(c => c.NameCity); break;
                }
            }

            allStudent = allStudent.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE);
            var result = allStudent.Select(c => new CityModelView
            {
                IdCity = c.IdCity,
                NameCity = c.NameCity,
                TitleCity= c.TitleCity,
                NameNation = c.Nation != null ? c.Nation.NameNation: ""
            });
            return result.ToList();
        }
    }
}

