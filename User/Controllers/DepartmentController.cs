using Microsoft.AspNetCore.Mvc;
using User.Data;
using User.Models;

namespace User.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DepartmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Department.ToList());
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            _context.Department.Add(department);
            _context.SaveChanges();

            return Ok(department);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var department = _context.Department.Find(id);

            if (department == null)
                return NotFound();

            _context.Department.Remove(department);
            _context.SaveChanges();

            return Ok();
        }
    }
}