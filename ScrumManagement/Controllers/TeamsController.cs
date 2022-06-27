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
    public class TeamsController : ControllerBase {
        private readonly AppDbContext _context;

        public TeamsController(AppDbContext context) {
            _context = context;
        }

        // GET: api/Teams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams() {
            if (_context.Teams == null) {
                return NotFound();
            }
            return await _context.Teams.Include(x => x.TeamList)
                .ThenInclude(x => x.TeamMember)
                .Include(x => x.Product)
                .ToListAsync();
        }

        // GET: api/Teams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id) {
            if (_context.Teams == null) {
                return NotFound();
            }
            var team = await _context.Teams.Include(x => x.TeamList).
                ThenInclude(x => x.TeamMember).ThenInclude(x => x.StrengthList).ThenInclude(x => x.Strength)
                .Include(x => x.Product)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (team == null) {
                return NotFound();
            }

            return team;
        }
        //get myteam
        [HttpGet("myteam/{userid}")]
        public async Task<ActionResult<Team>> GetMyTeam(int userid) {
            var findteamId = (from t in _context.Teams
                          join tl in _context.TeamLists on t.Id equals tl.TeamId
                          where tl.TeamMemberId == userid
                          select tl.TeamId
                          ).Sum();
            if(findteamId == 0) { return NotFound(); }
            
            
            var team = await _context.Teams.Include(x => x.TeamList)
                .ThenInclude(x => x.TeamMember)
                .ThenInclude(x => x.StrengthList)
                .ThenInclude(x => x.Strength)
                .SingleOrDefaultAsync(x => x.Id == findteamId);

            return team;
        }
        //get PO
        [HttpGet("po/{teamid}")]
        public Task<ActionResult<string>> GetTeamPO(int teamid) {
            
            var po =  (from t in _context.Teams
                     join tl in _context.TeamLists on t.Id equals tl.TeamId
                     join tm in _context.TeamMembers on tl.TeamMemberId equals tm.Id
                     where tm.Role == "Product Owner" && t.Id == teamid
                     select new {tm.Name });
            return (Task<ActionResult<string>>)po;
        }
        // PUT: api/Teams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(int id, Team team)
        {
            if (id != team.Id)
            {
                return BadRequest();
            }

            _context.Entry(team).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
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

        // POST: api/Teams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam(Team team)
        {
          if (_context.Teams == null)
          {
              return Problem("Entity set 'AppDbContext.Teams'  is null.");
          }
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeam", new { id = team.Id }, team);
        }

        // DELETE: api/Teams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            if (_context.Teams == null)
            {
                return NotFound();
            }
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeamExists(int id)
        {
            return (_context.Teams?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
