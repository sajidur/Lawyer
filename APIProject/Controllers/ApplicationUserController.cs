using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIProject.Models;
using APIProject.Request;
using APIProject.Response;
using APIProject.BL;

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
        public async Task<ActionResult> GetUsers()
        {
            var res = new ResponseClass();
            try
            {
                res.status = true;
                res.data = _context.Users;
            }
            catch (Exception ex)
            {
                res.data = ex.Message;
            }
            return res.ToJson();
        }

        // GET: api/ApplicationUser/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsers([FromRoute] int id)
        {
            var res = new ResponseClass();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users = await _context.Users.FindAsync(id);

            if (users == null)
            {
               return res.ToJson();
            }
            else
            {
                res.status = true;
                res.data = users;
            }
            return res.ToJson();
           
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
            var res = new ResponseClass();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (string.IsNullOrEmpty(userRequest.Mobile))
            {
                res.status = false;
                res.data = 0;
            }
            try
            {
                var alreadyExists = _context.Users.Where(a => a.Mobile == userRequest.Mobile).FirstOrDefault();
                if (alreadyExists != null)
                {
                    res.status = true;
                    res.data = alreadyExists.Id;
                }
                else
                {
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
                    var _res = _context.SaveChanges();
                }
                var lastid = _context.Users.Where(a => a.Mobile == userRequest.Mobile).FirstOrDefault();
                res.status = true;
                res.data = lastid.Id;
                if (userRequest.UserType==2)
                {
                    ClientProfileService service = new ClientProfileService(_context);
                    var clientRequest = new ClientProfileRequest() { Mobile = userRequest.Mobile, UserId = lastid.Id };
                    service.Add(clientRequest);
                }
                else
                {
                    LawyerProfileService service = new LawyerProfileService(_context);
                    var clientRequest = new LawyerProfileRequest() { Mobile = userRequest.Mobile, UserId = lastid.Id };
                    service.Add(clientRequest);
                }
                return res.ToJson();
            }
            catch (Exception ex)
            {
                res.status = false;
                res.data = ex.Message;
                return CreatedAtAction("GetUsers", res);
            }

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