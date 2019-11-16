﻿using System;
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
using APIProject.Response;

namespace APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientProfilesController : ControllerBase
    {
        private readonly LawyerAPIDBContext _context;

        public ClientProfilesController(LawyerAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/ClientProfiles
        [HttpGet]
        public IEnumerable<ClientProfile> GetClientProfile()
        {
            return _context.ClientProfile;
        }

        // GET: api/ClientProfiles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientProfile([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clientProfile = await _context.ClientProfile.FindAsync(id);

            if (clientProfile == null)
            {
                return NotFound();
            }

            return Ok(clientProfile);
        }

        // PUT: api/ClientProfiles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientProfile([FromRoute] int id, [FromBody] ClientProfile clientProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clientProfile.Id)
            {
                return BadRequest();
            }

            _context.Entry(clientProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientProfileExists(id))
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

        // POST: api/ClientProfiles
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> PostClientProfile(CustomerProfileRequest userRequest)
        {
            var res = new ResponseClass();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var clientProfile = new ClientProfile()
                {
                    Address = userRequest.Address,
                    Mobile = userRequest.Mobile,
                    Name = userRequest.Name,
                    IsActive = true,
                    CreatedDate = new DateTime(),
                    UpdatedDate = new DateTime()
                };
                _context.ClientProfile.Add(clientProfile);
                await _context.SaveChangesAsync();
                res.status = true;
                res.data = userRequest.Mobile;
            }
            catch (Exception ex)
            {
                res.status = false;
                res.data = ex.Message;
            }

            return CreatedAtAction("GetClientProfile", res);
        }

        // DELETE: api/ClientProfiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientProfile([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clientProfile = await _context.ClientProfile.FindAsync(id);
            if (clientProfile == null)
            {
                return NotFound();
            }

            _context.ClientProfile.Remove(clientProfile);
            await _context.SaveChangesAsync();

            return Ok(clientProfile);
        }

        private bool ClientProfileExists(int id)
        {
            return _context.ClientProfile.Any(e => e.Id == id);
        }
    }
}