using student.Data;
using student.Models;

namespace student.Services
{
    public class WardRespository : IWardRespository
    {
        private readonly MyDbContext _context;
        public static int PAGE_SIZE { get; set; } = 5;

        public WardRespository(MyDbContext context)
        {
            _context = context;
        }

        public List<WardModelView> GetAllWard(string? search, string? sortBy, int page = 1)
        {
            var allStudent = _context.Wards.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                allStudent = allStudent.Where(w => (w.NameWard != null ? w.NameWard : "").Contains(search));
            }

            allStudent = allStudent.OrderBy(w => w.NameWard);
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "w_desc": allStudent = allStudent.OrderByDescending(w => w.NameWard); break;
                }
            }

            allStudent = allStudent.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE);
            var result = allStudent.Select(w => new WardModelView
            {
                IdWard = w.IdWard,
                NameWard = w.NameWard,
                TitleWard = w.TitleWard,
                NameDistrict = w.District != null ? w.District.NameDistrict : ""
            });
            return result.ToList();
        }
    }
}
