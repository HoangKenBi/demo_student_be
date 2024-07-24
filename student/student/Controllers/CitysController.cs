using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using student.Data;
using student.Models;
using student.Services;

namespace student.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitysController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly ICityRespository _cityRespository;

        public CitysController(MyDbContext context, ICityRespository cityRespository)
        {
            _context = context;
            _cityRespository = cityRespository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _context.Citys.ToList();
            return Ok(list);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var city = _context.Citys.SingleOrDefault(c => c.IdCity == id);
            if(city != null)
            {
                return Ok(city);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Add(CityModel model)
        {
            try
            {
                var city = new City
                {
                    NameCity = model.NameCity,
                    TitleCity = model.TitleCity,
                    IdNation = model.IdNation
                };
                _context.Add(city);
                _context.SaveChanges();
                return Ok(city);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(CityModel model, int id)
        {
            var city = _context.Citys.SingleOrDefault(c => c.IdCity == id);
            if(city != null)
            {
                city.NameCity = model.NameCity;
                city.TitleCity = model.TitleCity;
                city.IdNation = model.IdNation;
                _context.Update(city);
                _context.SaveChanges();
                return Ok(city);
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
                var city = _context.Citys.SingleOrDefault(c => c.IdCity == id);
                if (city != null)
                {
                    _context.Remove(city);
                    _context.SaveChanges();
                    return Ok(city);
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
        public IActionResult GetAllStuCity(string? search, string? sortBy, int page = 1)
        {
            try
            {
                var result = _cityRespository.GetAllCity(search, sortBy, page);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
