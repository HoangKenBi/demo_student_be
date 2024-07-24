using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using student.Data;
using student.Models;
using student.Services;

namespace student.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WardsController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IWardRespository _wardRespository;

        public WardsController(MyDbContext context, IWardRespository wardRespository)
        {
            _context = context;
            _wardRespository = wardRespository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _context.Wards.ToList();
            return Ok(list);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ward = _context.Wards.SingleOrDefault(w => w.IdWard == id);
            if(ward != null)
            {
                return Ok(ward);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Add(WardModel model)
        {
            try
            {
                var ward = new Ward
                {
                    NameWard = model.NameWard,
                    TitleWard = model.TitleWard,
                    IdDistrict = model.IdDistrict
                };
                _context.Add(ward);
                _context.SaveChanges();
                return Ok(ward);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(WardModel model, int id)
        {
            var ward = _context.Wards.SingleOrDefault(w => w.IdWard == id);
            if(ward != null)
            {
                ward.NameWard = model.NameWard;
                ward.TitleWard = model.TitleWard;
                ward.IdDistrict = model.IdDistrict;
                _context.Update(ward);
                _context.SaveChanges();
                return Ok(ward);
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
                var ward = _context.Wards.SingleOrDefault(w => w.IdWard == id);
                if(ward != null)
                {
                    _context.Remove(ward);
                    _context.SaveChanges();
                    return Ok(ward);
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
        public IActionResult GetAllStuWard(string? search, string? sortBy, int page = 1)
        {
            try
            {
                var result = _wardRespository.GetAllWard(search, sortBy, page);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
