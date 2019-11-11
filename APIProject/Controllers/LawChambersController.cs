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
    public class LawChambersController : ControllerBase
    {
        private readonly LawyerAPIDBContext _context;

        public LawChambersController(LawyerAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/LawChambers
        [HttpGet]
        public IEnumerable<LawChamber> GetLawChambers()
        {
            return _context.LawChambers;
        }

        // GET: api/LawChambers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLawChamber([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lawChamber = await _context.LawChambers.FindAsync(id);

            if (lawChamber == null)
            {
                return NotFound();
            }

            return Ok(lawChamber);
        }

        // PUT: api/LawChambers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLawChamber([FromRoute] int id, [FromBody] LawChamber lawChamber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lawChamber.Id)
            {
                return BadRequest();
            }

            _context.Entry(lawChamber).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LawChamberExists(id))
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

        // POST: api/LawChambers
        [HttpPost]
        public async Task<IActionResult> PostLawChamber([FromBody] LawChamber lawChamber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.LawChambers.Add(lawChamber);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLawChamber", new { id = lawChamber.Id }, lawChamber);
        }

        // DELETE: api/LawChambers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLawChamber([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lawChamber = await _context.LawChambers.FindAsync(id);
            if (lawChamber == null)
            {
                return NotFound();
            }

            _context.LawChambers.Remove(lawChamber);
            await _context.SaveChangesAsync();

            return Ok(lawChamber);
        }

        private bool LawChamberExists(int id)
        {
            return _context.LawChambers.Any(e => e.Id == id);
        }
    }
}