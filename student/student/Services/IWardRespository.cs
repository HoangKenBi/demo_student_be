using student.Models;

namespace student.Services
{
    public interface IWardRespository
    {
        List<WardModelView> GetAllWard(string? search, string? sortBy, int page = 1);
    }
}
