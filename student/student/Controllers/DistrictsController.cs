using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using student.Data;
using student.Models;
using student.Services;

namespace student.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictsController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IDistrictRespository _districtRespository;

        public DistrictsController(MyDbContext context, IDistrictRespository districtRespository)
        {
            _context = context;
            _districtRespository = districtRespository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _context.Districts.ToList();
            return Ok(list);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var district = _context.Districts.SingleOrDefault(d => d.IdDistrict == id);
            if(district != null)
            {
                return Ok(district);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Add(DistrictModel model)
        {
            try
            {
                var district = new District
                {
                    NameDistrict = model.NameDistrict,
                    TitleDistrict = model.TitleDistrict,
                    IdCity = model.IdCity,
                };
                _context.Add(district);
                _context.SaveChanges();
                return Ok(district);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(DistrictModel model, int id)
        {
            var district = _context.Districts.SingleOrDefault(d => d.IdDistrict == id);
            if(district != null)
            {
                district.NameDistrict = model.NameDistrict;
                district.TitleDistrict = model.TitleDistrict;
                district.IdCity = model.IdCity;
                _context.Update(district);
                _context.SaveChanges();
                return Ok(district);
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
                var district = _context.Districts.SingleOrDefault(d => d.IdDistrict == id);
                if(district != null)
                {
                    _context.Remove(district);
                    _context.SaveChanges();
                    return Ok(district);
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
        public IActionResult GetAllStuDistric(string? search, string? sortBy, int page = 1)
        {
            try
            {
                var result = _districtRespository.GetAllDistrict(search, sortBy, page);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
