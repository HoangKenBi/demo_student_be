using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using student.Data;
using student.Models;
using student.Services;

namespace student.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationsController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly INationRespository _nationRespository;

        public NationsController(MyDbContext context, INationRespository nationRespository)
        {
            _context = context;
            _nationRespository = nationRespository;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _context.Nations.ToList();
            return Ok(list);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var nation = _context.Nations.SingleOrDefault(n => n.IdNation == id);
            if(nation != null)
            {
                return Ok(nation);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Add(NationModel model)
        {
            try
            {
                var nation = new Nation
                {
                    NameNation = model.NameNation,
                    TitleNation = model.TitleNation
                };
                _context.Add(nation);
                _context.SaveChanges();
                return Ok(nation);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, NationModel mode)
        {
            var nation = _context.Nations.SingleOrDefault(n => n.IdNation == id);
            if(nation != null)
            {
                nation.NameNation = mode.NameNation;
                nation.TitleNation = mode.TitleNation;
                _context.Update(nation);
                _context.SaveChanges();
                return Ok(nation);
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
                var nation = _context.Nations.SingleOrDefault(n => n.IdNation == id);
                if(nation != null)
                {
                    _context.Remove(nation);
                    _context.SaveChanges();
                    return Ok(nation);
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
        public IActionResult GetAllStuNation(string? search, string? sortBy, int page = 1)
        {
            try
            {
                var result = _nationRespository.GetAllNation(search, sortBy, page);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
