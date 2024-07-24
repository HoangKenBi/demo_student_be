using student.Models;

namespace student.Services
{
    public interface ICityRespository
    {
        List<CityModelView> GetAllCity(string? search, string? sortBy, int page = 1);

    }
}
