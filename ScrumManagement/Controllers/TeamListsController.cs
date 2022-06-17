using System;
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
    public class TeamListsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TeamListsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TeamLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamList>>> GetTeamLists()
        {
          if (_context.TeamLists == null)
          {
              return NotFound();
          }
            return await _context.TeamLists.ToListAsync();
        }

        // GET: api/TeamLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamList>> GetTeamList(int id)
        {
          if (_context.TeamLists == null)
          {
              return NotFound();
          }
            var teamList = await _context.TeamLists.FindAsync(id);

            if (teamList == null)
            {
                return NotFound();
            }

            return teamList;
        }

        // PUT: api/TeamLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeamList(int id, TeamList teamList)
        {
            if (id != teamList.Id)
            {
                return BadRequest();
            }

            _context.Entry(teamList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamListExists(id))
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

        // POST: api/TeamLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TeamList>> PostTeamList(TeamList teamList)
        {
          if (_context.TeamLists == null)
          {
              return Problem("Entity set 'AppDbContext.TeamLists'  is null.");
          }
            _context.TeamLists.Add(teamList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeamList", new { id = teamList.Id }, teamList);
        }

        // DELETE: api/TeamLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeamList(int id)
        {
            if (_context.TeamLists == null)
            {
                return NotFound();
            }
            var teamList = await _context.TeamLists.FindAsync(id);
            if (teamList == null)
            {
                return NotFound();
            }

            _context.TeamLists.Remove(teamList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeamListExists(int id)
        {
            return (_context.TeamLists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
