using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIProject;
using APIProject.Models;
using APIProject.Models;
using APIProject.Request;

namespace APIProject.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly LawyerAPIDBContext _context;

        public ApplicationUserController(LawyerAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/ApplicationUser
        [HttpGet]
        public IEnumerable<Users> GetUsers()
        {
            return _context.Users;
        }

        // GET: api/ApplicationUser/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users = await _context.Users.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // PUT: api/ApplicationUser/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers([FromRoute] int id, [FromBody] Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users.Id)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
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

        // POST: api/ApplicationUser
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(UserRequest userRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var alreadyExists = _context.Users.Where(a => a.Mobile == userRequest.Mobile).FirstOrDefault();
            if (alreadyExists!=null)
            {
                return CreatedAtAction("GetUsers", alreadyExists.Id);
            }
            var users = new Users()
            {
                Address = userRequest.Address,
                Mobile = userRequest.Mobile,
                UserType = userRequest.UserType,
                Name = userRequest.Name,
                IsActive = true,
                CreatedDate = new DateTime(),
                UpdatedDate = new DateTime()
            };
            _context.Users.Add(users);
            await _context.SaveChangesAsync();
            var lastid = _context.Users.LastOrDefault();
            return CreatedAtAction("GetUsers", lastid.Id);
        }

        // DELETE: api/ApplicationUser/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.Users.Remove(users);
            await _context.SaveChangesAsync();

            return Ok(users);
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}