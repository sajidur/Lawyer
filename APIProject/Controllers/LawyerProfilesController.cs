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
using Microsoft.Extensions.Logging;
using APIProject.BL;

namespace APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LawyerProfilesController : ControllerBase
    {
        private readonly LawyerAPIDBContext _context;
        private readonly ILogger _logger;
        public LawyerProfilesController(LawyerAPIDBContext context, ILogger<LawyerProfilesController> logger)
        {
            _context = context;
            _logger = logger;
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

            var lawyerProfile =  _context.LawyerProfile.Include(a => a.Users).Include(a => a.Address).Include(a => a.ProfilePic).Include(a => a.Bio).Include(a => a.Education).Include(a => a.Experience).Include(a => a.PackageSettings).Where(a=>a.Users.Id==id).FirstOrDefault();

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
            _logger.LogInformation("PutLawyerProfile| {Message}", lawyerProfile.ToJson());
            var res = new ResponseClass();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var profile = _context.LawyerProfile.Where(a => a.Users.Id == id).FirstOrDefault();
            if (profile != null)
            {
                profile.Name = lawyerProfile.Name;
                profile.UpdatedDate = DateTime.Now;
                profile.Address = lawyerProfile.Address;
                profile.Education = lawyerProfile.Education;
                profile.Experience = lawyerProfile.Experience;
                profile.PackageSettings = lawyerProfile.PackageSettings;
                profile.WorkingArea = lawyerProfile.WorkingArea;
                profile.Bio = lawyerProfile.Bio;
                profile.BioCharLimit = lawyerProfile.BioCharLimit;
                _context.Entry(profile).State = EntityState.Modified;
            }
            else
            {
                    res.data = "Profile not found";
                    return res.ToJson();
            }
            _context.LawyerProfile.Update(profile);

            //_context.Entry(lawyerProfile).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
                res.status = true;
                res.data = "Sucessfully Updated";
            }
            catch (DbUpdateConcurrencyException ex)
            {
                res.data = "Profile not updated|"+ex.Message;
                return res.ToJson();
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
            LawyerProfileService service = new LawyerProfileService(_context);
            return service.Add(userRequest).ToJson();

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
            _context.SaveChanges();

            return Ok(lawyerProfile);
        }

        private bool LawyerProfileExists(int id)
        {
            return _context.LawyerProfile.Any(e => e.Id == id);
        }
    }
}