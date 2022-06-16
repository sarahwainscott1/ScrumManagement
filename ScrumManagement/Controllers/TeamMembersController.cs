﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScrumManagement.Models;

namespace ScrumManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMembersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private const string Inactive = "INACTIVE";

        public TeamMembersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TeamMembers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamMember>>> GetTeamMembers()
        {
          if (_context.TeamMembers == null)
          {
              return NotFound();
          }
            return await _context.TeamMembers.Include(x => x.StrengthList).ThenInclude(x => x.Strength).ToListAsync();
        }

        // GET: api/TeamMembers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamMember>> GetTeamMember(int id)
        {
          if (_context.TeamMembers == null)
          {
              return NotFound();
          }
            var teamMember = await _context.TeamMembers
               .Include(x => x.Story)
               .Include(x => x.Coach)
               .Include(x => x.StrengthList).ThenInclude(x => x.Strength)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (teamMember == null)
            {
                return NotFound();
            }

            return teamMember;
        }
        //login
        [HttpGet("login/{email}/{password}")]
        public async Task<ActionResult<TeamMember>> Login(string email, string password) {
            if (_context.TeamMembers == null) { return NotFound(); }
            var teamMember = await _context.TeamMembers.SingleOrDefaultAsync(x => x.Email == email && x.Password == password);
            if (teamMember == null) { return NotFound(); }
            return teamMember;
        }

     
        // PUT: api/TeamMembers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeamMember(int id, TeamMember teamMember)
        {
            if (id != teamMember.Id)
            {
                return BadRequest();
            }
         
            _context.Entry(teamMember).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamMemberExists(id))
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
        //deactivate
        [HttpPut("deactivate/{id}")]
        public async Task<IActionResult> Deactivate(int id, TeamMember teamMember) {
            if (teamMember == null) { return NotFound(); }
            teamMember.Role = Inactive;
            return await PutTeamMember(id, teamMember);
        }
        // POST: api/TeamMembers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TeamMember>> PostTeamMember(TeamMember teamMember)
        {
          if (_context.TeamMembers == null)
          {
              return Problem("Entity set 'AppDbContext.TeamMembers'  is null.");
          }
     
            _context.TeamMembers.Add(teamMember);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeamMember", new { id = teamMember.Id }, teamMember);
        }

        // DELETE: api/TeamMembers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeamMember(int id)
        {
            if (_context.TeamMembers == null)
            {
                return NotFound();
            }
            var teamMember = await _context.TeamMembers.FindAsync(id);
            if (teamMember == null)
            {
                return NotFound();
            }

            _context.TeamMembers.Remove(teamMember);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeamMemberExists(int id)
        {
            return (_context.TeamMembers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
