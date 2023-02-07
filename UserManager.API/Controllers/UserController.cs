using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManager.API;
using UserManager.Shared.DataTransferObjects;
using UserManager.Shared.Models;

namespace UserManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManagerDbContext _context;

        public UserController(UserManagerDbContext context)
        {
            _context = context;
        }


        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            return await _context.User.Select(user => new UserDTO()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
            }).ToListAsync();
        }


        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetailDTO>> GetUser(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return new UserDetailDTO()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                CompanyId = user.CompanyId,
                Company = _context.Company.Where(c => c.Id == user.CompanyId).Select(c => new CompanyDTO()
                {
                    Id = c.Id,
                    Name = c.Name,
                }).First(),
                GroupId = user.GroupId,
            };
        }


        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserDetailDTO userDTO)
        {
            if (id != userDTO.Id)
            {
                return BadRequest();
            }

            var user = new User()
            {
                Id = userDTO.Id,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Company = await _context.Company.Where(c => c.Id == userDTO.CompanyId).FirstAsync(),
                CompanyId = userDTO.CompanyId,
                Group = await _context.UserGroup.Where(g => g.Id == userDTO.GroupId).FirstAsync(),
                GroupId = userDTO.GroupId,
            };

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserDetailDTO>> PostUser(UserDetailDTO userDto)
        {

            var company = await _context.Company.FindAsync(userDto.CompanyId);
            if (company == null) { return BadRequest("Invalid companyId"); }

            var group = await _context.UserGroup.FindAsync(userDto.GroupId);
            if (group == null) { return BadRequest("Invalid userGroupId"); }


            // Convert DTO to normal user
            var user = new User()
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                CompanyId = userDto.CompanyId,
                GroupId = userDto.GroupId,
            };

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, userDto);
        }


        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
