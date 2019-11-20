using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIProject;
using APIProject.Models;
using APIProject.Response;
using APIProject.Request;

namespace APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LawyerProfilesController : ControllerBase
    {
        private readonly LawyerAPIDBContext _context;

        public LawyerProfilesController(LawyerAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/LawyerProfiles
        [HttpGet]
        public async Task<IActionResult>  GetLawyerProfile()
        {
            var res = new ResponseClass();
            try
            {
                res.data = _context.LawyerProfile.Include(a => a.Users).Include(a => a.Address).Include(a=>a.ProfilePic).Include(a=>a.Bio).Include(a=>a.Education).Include(a=>a.Experience).Include(a=>a.PackageSettings);
                res.status = true;

            }
            catch (Exception ex)
            {
                res.data = ex.Message;
            }
            return res.ToJson();
        }

        // GET: api/LawyerProfiles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLawyerProfile([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lawyerProfile = await _context.LawyerProfile.FindAsync(id);

            if (lawyerProfile == null)
            {
                return NotFound();
            }

            return Ok(lawyerProfile);
        }

        // PUT: api/LawyerProfiles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLawyerProfile([FromRoute] int id, [FromBody] LawyerProfile lawyerProfile)
        {
            var res = new ResponseClass();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lawyerProfile.Id)
            {
                res.data = "Id and Profile id not matched";
                return res.ToJson();
            }

            _context.Entry(lawyerProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                res.status = true;
                res.data = "Sucessfully Updated";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LawyerProfileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return res.ToJson();
        }

        // POST: api/LawyerProfiles
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> PostLawyerProfile(LawyerProfileRequest userRequest)
        {
            var res = new ResponseClass();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var users = _context.Users.Where(a => a.Id == userRequest.UserId).FirstOrDefault();
                if (users == null)
                {
                    res.data = "User not found with the Id";
                    return res.ToJson();
                }
                var alreadyExists = _context.LawyerProfile.Where(a => a.Users.Id == userRequest.UserId).FirstOrDefault();
                if (alreadyExists != null)
                {
                    res.data = "User not found with the Id";
                    return res.ToJson();
                }
                var lawprofile = new LawyerProfile()
                {

                    Address = userRequest.Address,
                    Mobile = userRequest.Mobile,
                    Name = userRequest.Name,
                    IsActive = true,
                    CreatedDate = new DateTime(),
                    UpdatedDate = new DateTime(),
                    Users = users,
                    Bio=userRequest.Bio,
                    BioCharLimit=userRequest.BioCharLimit,
                    WorkingArea=userRequest.WorkingArea,
                    Education=userRequest.Education,
                    Experience=userRequest.Experience,
                    PackageSettings=userRequest.PackageSettings,
                    ProfilePic=userRequest.ProfilePic
                };
                _context.LawyerProfile.Add(lawprofile);
                await _context.SaveChangesAsync();
                var lastLawer = _context.LawyerProfile.LastOrDefault();
                res.status = true;
                res.data = userRequest.Mobile;
            }
            catch (Exception ex)
            {
                res.status = false;
                res.data = ex.Message;
            }

            return CreatedAtAction("GetLawyerProfile", res);
        }

        // DELETE: api/LawyerProfiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLawyerProfile([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lawyerProfile = await _context.LawyerProfile.FindAsync(id);
            if (lawyerProfile == null)
            {
                return NotFound();
            }

            _context.LawyerProfile.Remove(lawyerProfile);
            await _context.SaveChangesAsync();

            return Ok(lawyerProfile);
        }

        private bool LawyerProfileExists(int id)
        {
            return _context.LawyerProfile.Any(e => e.Id == id);
        }
    }
}