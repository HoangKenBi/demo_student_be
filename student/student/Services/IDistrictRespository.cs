using student.Models;

namespace student.Services
{
    public interface IDistrictRespository
    {
        List<DistrictModelView> GetAllDistrict(string? search, string? sortBy, int page = 1);
    }
}
