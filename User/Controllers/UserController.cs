using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using User.Data;
using User.DTOs;
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
        public async Task<IActionResult> CreateUser(CreateUserDto dto)
        {
            var user = new Users
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Age = dto.Age,
                DepartmentId = dto.DepartmentId,

                Address = new Address
                {
                    City = dto.Address.City,
                    State = dto.Address.State,
                    Country = dto.Address.Country
                }
            };

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Users
                .Include(u => u.Department)
                .Include(u => u.Address)
                .ToListAsync();

            return Ok(users);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserDto dto)
        {
            var existingUser = await _context.Users
                .Include(u => u.Address)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (existingUser == null)
                return NotFound();

            existingUser.FirstName = dto.FirstName;
            existingUser.LastName = dto.LastName;
            existingUser.Email = dto.Email;
            existingUser.Age = dto.Age;
            existingUser.DepartmentId = dto.DepartmentId;

            existingUser.Address.City = dto.Address.City;
            existingUser.Address.State = dto.Address.State;
            existingUser.Address.Country = dto.Address.Country;

            await _context.SaveChangesAsync();

            return Ok(existingUser);
        }

        [HttpDelete("{id}")]
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