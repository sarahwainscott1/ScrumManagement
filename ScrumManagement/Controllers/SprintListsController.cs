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
    public class SprintListsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SprintListsController(AppDbContext context)
        {
            _context = context;
        }
        //calculate totals
        private async Task<ActionResult> CalculateSprintTotals(int? sprintId) {
            var sprint = await _context.Sprints.FindAsync(sprintId);
            if (sprint == null) { throw new Exception("No Sprint found"); }
            sprint.TotalTime = (from sl in _context.SprintList
                                join sp in _context.Sprints on sl.SprintId equals sp.Id
                                where sp.Id == sprintId
                                select new {
                                    StoryTime = sl.Story.ActualTime
                                }).Sum(x => x.StoryTime);
            sprint.TotalPoints = (from sl in _context.SprintList
                                  join sp in _context.Sprints on sl.SprintId equals sp.Id
                                  where sp.Id == sprintId
                                  select new {
                                      StoryPoints = sl.Story.EstimatedPoints
                                  }).Sum(x => x.StoryPoints);
            sprint.RemainingPoints = sprint.MaxPoints - sprint.TotalPoints;
            await _context.SaveChangesAsync();
            return Ok();
        }
        // GET: api/SprintLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SprintList>>> GetSprintList()
        {
          if (_context.SprintList == null)
          {
              return NotFound();
          }
            return await _context.SprintList.ToListAsync();
        }

        // GET: api/SprintLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SprintList>> GetSprintList(int id)
        {
          if (_context.SprintList == null)
          {
              return NotFound();
          }
            var sprintList = await _context.SprintList.FindAsync(id);

            if (sprintList == null)
            {
                return NotFound();
            }

            return sprintList;
        }

        // PUT: api/SprintLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSprintList(int id, SprintList sprintList)
        {
            if (id != sprintList.Id)
            {
                return BadRequest();
            }

            _context.Entry(sprintList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                await CalculateSprintTotals(sprintList.SprintId);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SprintListExists(id))
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

        // POST: api/SprintLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SprintList>> PostSprintList(SprintList sprintList)
        {
          if (_context.SprintList == null)
          {
              return Problem("Entity set 'AppDbContext.SprintList'  is null.");
          }
            _context.SprintList.Add(sprintList);
            await _context.SaveChangesAsync();
            await CalculateSprintTotals(sprintList.SprintId);

            return CreatedAtAction("GetSprintList", new { id = sprintList.Id }, sprintList);
        }

        // DELETE: api/SprintLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSprintList(int id)
        {
            if (_context.SprintList == null)
            {
                return NotFound();
            }
            var sprintList = await _context.SprintList.FindAsync(id);
            if (sprintList == null)
            {
                return NotFound();
            }

            _context.SprintList.Remove(sprintList);
            await _context.SaveChangesAsync();
            await CalculateSprintTotals(sprintList.SprintId);

            return NoContent();
        }

        private bool SprintListExists(int id)
        {
            return (_context.SprintList?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
