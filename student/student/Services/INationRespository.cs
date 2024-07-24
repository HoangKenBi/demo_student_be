using student.Models;

namespace student.Services
{
    public interface INationRespository
    {
        List<NationModelView> GetAllNation(string? search, string? sortBy, int page = 1);
    }
}
