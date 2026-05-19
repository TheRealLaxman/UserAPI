using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using User.Data;
using User.Models;

namespace User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(Users entity)
        {
            _context.Users.Add(entity);

            await _context.SaveChangesAsync();

            return Ok(entity);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Users.ToListAsync();

            return Ok(users);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(Users entity)
        {
            var existingUser = await _context.Users.FindAsync(entity.Id);

            if (existingUser == null)
                return NotFound();

            existingUser.FirstName = entity.FirstName;
            existingUser.LastName = entity.LastName;
            existingUser.Email = entity.Email;
            existingUser.Age = entity.Age;

            await _context.SaveChangesAsync();

            return Ok(existingUser);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return NotFound();

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}