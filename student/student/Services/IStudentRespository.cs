using student.Models;

namespace student.Services
{
    public interface IStudentRespository
    {
        List<StudentModelView> GetAllStudent(string? search, string? sortBy, int page = 1);
    }
}
