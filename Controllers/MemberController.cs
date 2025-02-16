using Microsoft.AspNetCore.Mvc;
using LibrarySystem.Data;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.DTOs;

namespace LibrarySystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly LibraryContext _context;

        public UsersController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetUsers([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            return await _context.Members
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetUser(int id)
        {
            var user = await _context.Members.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        // POST: api/users
        [HttpPost]
        public async Task<ActionResult<Member>> AddUser(MemberDto memberDto)
        {
            var member = new Member
            {
                Name = memberDto.Name,
                Email = memberDto.Email
            };


            _context.Members.Add(member);
            await _context.SaveChangesAsync();

            var result = new MemberDto
            {
                Id = member.Id,
                Name = member.Name,
                Email = member.Email
            };

            return CreatedAtAction(nameof(GetUser), new { id = member.Id }, result);
        }

        // PUT: api/users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, Member user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Members.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Members.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}