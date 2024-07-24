using student.Data;
using student.Models;

namespace student.Services
{
    public class NationRespository : INationRespository
    {
        private readonly MyDbContext _context;
        public static int PAGE_SIZE { get; set; } = 5;

        public NationRespository(MyDbContext context)
        {
            _context = context;
        }
        public List<NationModelView> GetAllNation(string? search, string? sortBy, int page = 1)
        {
            var allStudent = _context.Nations.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                allStudent = allStudent.Where(n => (n.NameNation != null ? n.NameNation : "").Contains(search));
            }

            allStudent = allStudent.OrderBy(n => n.NameNation);
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "n_desc": allStudent = allStudent.OrderByDescending(n => n.NameNation); break;
                }
            }

            allStudent = allStudent.Skip((page-1)* PAGE_SIZE).Take(PAGE_SIZE);
            var result = allStudent.Select(n => new NationModelView
            {
                IdNation = n.IdNation,
                NameNation = n.NameNation,
                TitleNation = n.TitleNation,
            });
            return result.ToList();
        }

    }
}
