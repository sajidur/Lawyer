using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIProject;
using APIProject.Models;

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
        public IEnumerable<LawyerProfile> GetLawyerProfile()
        {
            return _context.LawyerProfile;
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lawyerProfile.Id)
            {
                return BadRequest();
            }

            _context.Entry(lawyerProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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

            return NoContent();
        }

        // POST: api/LawyerProfiles
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> PostLawyerProfile( LawyerProfile userRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var lawyerProfile = new LawyerProfile()
            {
                Address = userRequest.Address,
                Mobile = userRequest.Mobile,
                Name = userRequest.Name,
                IsActive = true,
                CreatedDate = new DateTime(),
                UpdatedDate = new DateTime()
            };
            _context.LawyerProfile.Add(lawyerProfile);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetLawyerProfile", new { id = lawyerProfile.Id }, lawyerProfile);
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