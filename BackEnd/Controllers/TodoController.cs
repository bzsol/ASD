using BackEnd.Data;
using BackEnd.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ApiDbContext _context;
        public TodoController(ApiDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Todo>> Get()
        {
            return _context.todos;
        }
        [HttpPost]
        public ActionResult Post([FromBody] Todo todo)
        {
            _context.todos.Add(todo);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id) {
          var wanted = _context.todos.FirstOrDefault(x => x.id.Equals(id));
            if (wanted != null)
            {
                _context.todos.Remove(wanted);
                _context.SaveChanges();
                return Ok();
            }
            else {
                return NotFound();
            }
                
         
        }
        [HttpPut]
        public ActionResult Put([FromBody] Todo todo) {
            var wanted = _context.todos.FirstOrDefault(x => x.id.Equals(todo.id));
            if (wanted != null)
            {
                wanted.date = todo.date;
                wanted.description = todo.description;
                wanted.level = todo.level;
                wanted.title = todo.title;
                _context.todos.Update(wanted);
                return Ok();
            }
            else {
                return NotFound();
            }
        }
       
    }
}
