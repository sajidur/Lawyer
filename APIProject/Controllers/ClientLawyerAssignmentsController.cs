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
    public class ClientLawyerAssignmentsController : ControllerBase
    {
        private readonly LawyerAPIDBContext _context;

        public ClientLawyerAssignmentsController(LawyerAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/ClientLawyerAssignments
        [HttpGet]
        public IEnumerable<ClientLawyerAssignment> GetClientLawyerAssignment()
        {
            return _context.ClientLawyerAssignment;
        }

        // GET: api/ClientLawyerAssignments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientLawyerAssignment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clientLawyerAssignment = await _context.ClientLawyerAssignment.FindAsync(id);

            if (clientLawyerAssignment == null)
            {
                return NotFound();
            }

            return Ok(clientLawyerAssignment);
        }

        // PUT: api/ClientLawyerAssignments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientLawyerAssignment([FromRoute] int id, [FromBody] ClientLawyerAssignment clientLawyerAssignment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clientLawyerAssignment.Id)
            {
                return BadRequest();
            }

            _context.Entry(clientLawyerAssignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientLawyerAssignmentExists(id))
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

        // POST: api/ClientLawyerAssignments
        [HttpPost]
        public async Task<IActionResult> PostClientLawyerAssignment([FromBody] ClientLawyerAssignment clientLawyerAssignment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ClientLawyerAssignment.Add(clientLawyerAssignment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientLawyerAssignment", new { id = clientLawyerAssignment.Id }, clientLawyerAssignment);
        }

        // DELETE: api/ClientLawyerAssignments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientLawyerAssignment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clientLawyerAssignment = await _context.ClientLawyerAssignment.FindAsync(id);
            if (clientLawyerAssignment == null)
            {
                return NotFound();
            }

            _context.ClientLawyerAssignment.Remove(clientLawyerAssignment);
            await _context.SaveChangesAsync();

            return Ok(clientLawyerAssignment);
        }

        private bool ClientLawyerAssignmentExists(int id)
        {
            return _context.ClientLawyerAssignment.Any(e => e.Id == id);
        }
    }
}