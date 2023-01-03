using System;
using System.Collections.Generic;
using System.Linq;
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
    public class UserGroupController : ControllerBase
    {
        private readonly UserManagerDbContext _context;

        public UserGroupController(UserManagerDbContext context)
        {
            _context = context;
        }

        // GET: api/UserGroup
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserGroupDTO>>> GetUserGroups()
        {
            return await _context.UserGroup.Select(g => new UserGroupDTO()
                {
                    Id = g.Id,
                    Name = g.Name,
                    Users = _context.User.Where(u => u.GroupId == g.Id).Select(u => new UserDTO()
                        {
                            Id = u.Id,
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                        }).ToList()
                }).ToListAsync();
        }

        // GET: api/UserGroup/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserGroupDetailDTO>> GetUserGroup(int id)
        {
            var userGroup = await _context.UserGroup.FindAsync(id);

            if (userGroup == null) { return NotFound(); }

            var userGroupDto = new UserGroupDetailDTO()
            {
                Id = userGroup.Id,
                Name = userGroup.Name,
                ContributePermission = userGroup.ContributePermission,
                CreatePermission = userGroup.CreatePermission,
                ManagePermission = userGroup.ManagePermission,
                ReadPermission = userGroup.ReadPermission
            };

            return userGroupDto;
        }

        // PUT: api/UserGroup/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserGroup(int id, UserGroup userGroup)
        {
            if (id != userGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(userGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserGroupExists(id))
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


        // POST: api/UserGroup
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserGroup>> PostUserGroup(UserGroup userGroup)
        {
            _context.UserGroup.Add(userGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserGroup", new { id = userGroup.Id }, userGroup);
        }


        // DELETE: api/UserGroup/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserGroup(int id)
        {
            var userGroup = await _context.UserGroup.FindAsync(id);
            if (userGroup == null)
            {
                return NotFound();
            }

            _context.UserGroup.Remove(userGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool UserGroupExists(int id)
        {
            return _context.UserGroup.Any(e => e.Id == id);
        }
    }
}
