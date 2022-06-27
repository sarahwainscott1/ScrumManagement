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

    public class SprintsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private const string InProgress = "In Progress";
        private const string Concluded = "Concluded";
        private const string Cancelled = "Cancelled";

        public SprintsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Sprints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sprint>>> GetSprints()
        {
          if (_context.Sprints == null)
          {
              return NotFound();
          }
            return await _context.Sprints.Include(x => x.Product)
                .Include(x => x.SprintLists)
                .ThenInclude(x => x.Story).ToListAsync();
        }

        // GET: api/Sprints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sprint>> GetSprint(int id)
        {
          if (_context.Sprints == null)
          {
              return NotFound();
          }
            var sprint = await _context.Sprints.Include(x => x.Product)
                .Include(x => x.SprintLists)
                .ThenInclude(x => x.Story)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (sprint == null)
            {
                return NotFound();
            }

            return sprint;
        }
        //get my current sprint
        [HttpGet("currentsprint/{employeeId}")]
        public async Task<ActionResult<Sprint>> GetCurrentSprint(int employeeId) {
            
            var myTeamId = (from tl in _context.TeamLists
                            where tl.TeamMemberId == employeeId
                            select tl.TeamId).Single();

            var sprint = await _context.Sprints
                .Include(x => x.Product)
                .Include(x => x.SprintLists)
                .ThenInclude(x => x.Story)
                .Include(x => x.DailyScrums)
                .Where(x => x.Status == InProgress && x.TeamId == myTeamId)
                .SingleOrDefaultAsync(x => x.TeamId == myTeamId);

            return sprint; 
        }
        // PUT: api/Sprints/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSprint(int id, Sprint sprint)
        {
            if (id != sprint.Id)
            {
                return BadRequest();
            }

            _context.Entry(sprint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SprintExists(id))
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
        //Status to in progress
        [HttpPut("inprogress/{id}")]
        public async Task<IActionResult> SprintInProgress(int id, Sprint sprint) {
            sprint.Status = InProgress;
            return await PutSprint(id, sprint);
        }
        //status to concluded
        [HttpPut("concluded/{id}")]
        public async Task<IActionResult> SprintConcluded(int id, Sprint sprint) {
            sprint.Status = Concluded;
            return await PutSprint(id, sprint);
        }
        //status to cancelled
        [HttpPut("cancelled/{id}")]
        public async Task<IActionResult> SprintCancelled(int id, Sprint sprint) {
            sprint.Status = Cancelled;
            return await PutSprint(id, sprint);
        }
        // POST: api/Sprints
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sprint>> PostSprint(Sprint sprint)
        {
          if (_context.Sprints == null)
          {
              return Problem("Entity set 'AppDbContext.Sprints'  is null.");
          }
            _context.Sprints.Add(sprint);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSprint", new { id = sprint.Id }, sprint);
        }

        // DELETE: api/Sprints/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSprint(int id)
        {
            if (_context.Sprints == null)
            {
                return NotFound();
            }
            var sprint = await _context.Sprints.FindAsync(id);
            if (sprint == null)
            {
                return NotFound();
            }

            _context.Sprints.Remove(sprint);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SprintExists(int id)
        {
            return (_context.Sprints?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
