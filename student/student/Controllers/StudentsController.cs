using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using student.Data;
using student.Models;
using student.Services;

namespace student.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IStudentRespository _studentRespository;

        public StudentsController(MyDbContext context, IStudentRespository studentRespository)
        {
            _context = context;
            _studentRespository = studentRespository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _context.Students.ToList();
            return Ok(list);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _context.Students.SingleOrDefault(s => s.IdStudent == id);
            if(student != null)
            {
                return Ok(student);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Add(StudentModel model)
        {
            try
            {
                var student = new Student
                {
                    NameStudent = model.NameStudent,
                    PhoneStudent = model.PhoneStudent,
                    EmailStudent = model.EmailStudent,
                    BirthDayStudent = model.BirthDayStudent,
                    IdNation = model.IdNation,
                    IdCity = model.IdCity,
                    IdDistrict = model.IdDistrict,
                    IdWard = model.IdWard
                };
                _context.Add(student);
                _context.SaveChanges();
                return Ok(student);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(StudentModel model, int id)
        {
            var student = _context.Students.SingleOrDefault(s => s.IdStudent == id);
            if(student != null)
            {
                student.NameStudent = model.NameStudent;
                student.PhoneStudent = model.PhoneStudent;
                student.EmailStudent = model.EmailStudent;
                student.BirthDayStudent = model.BirthDayStudent;
                student.IdNation = model.IdNation;
                student.IdCity = model.IdCity;
                student.IdDistrict = model.IdDistrict;
                student.IdWard = model.IdWard;

                _context.Update(student);
                _context.SaveChanges();
                return Ok(student);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var student = _context.Students.SingleOrDefault(s => s.IdStudent == id);
                if(student != null)
                {
                    _context.Remove(student);
                    _context.SaveChanges();
                    return Ok(student);
                }
                else
                {
                    return NoContent();
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("search")]
        public IActionResult GetAllStuStudent(string? search, string? sortBy, int page = 1)
        {
            try
            {
                var result = _studentRespository.GetAllStudent(search, sortBy, page);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
