using BackEnd.Data;
using BackEnd.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaysController : ControllerBase
    {
        private readonly ApiDbContext _context;
        public DaysController(ApiDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Day>> Get()
        {
            return _context.days;
        }
        [HttpPost]
        public ActionResult Post([FromBody] Day day)
        {
            _context.days.Add(day);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id) {
          var wanted = _context.days.FirstOrDefault(x => x.id.Equals(id));
            if (wanted != null)
            {
                _context.days.Remove(wanted);
                _context.SaveChanges();
                return Ok();
            }
            else {
                return NotFound();
            }
                
         
        }
        [HttpPut]
        public ActionResult Put([FromBody] Day day) {
            var wanted = _context.days.FirstOrDefault(x => x.id.Equals(day.id));
            if (wanted != null)
            {
                wanted.date = day.date;
                wanted.description = day.description;
                wanted.happiness = day.happiness;
                wanted.motto = day.motto;
                _context.days.Update(wanted);
                return Ok();
            }
            else {
                return NotFound();
            }
        }
       
    }
}
