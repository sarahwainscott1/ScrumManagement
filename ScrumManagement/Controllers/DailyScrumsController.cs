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
    public class DailyScrumsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DailyScrumsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/DailyScrums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DailyScrum>>> GetDailyScrum()
        {
          if (_context.DailyScrum == null)
          {
              return NotFound();
          }
            return await _context.DailyScrum.ToListAsync();
        }

        // GET: api/DailyScrums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DailyScrum>> GetDailyScrum(int id)
        {
          if (_context.DailyScrum == null)
          {
              return NotFound();
          }
            var dailyScrum = await _context.DailyScrum.FindAsync(id);

            if (dailyScrum == null)
            {
                return NotFound();
            }

            return dailyScrum;
        }

        // PUT: api/DailyScrums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDailyScrum(int id, DailyScrum dailyScrum)
        {
            if (id != dailyScrum.Id)
            {
                return BadRequest();
            }

            _context.Entry(dailyScrum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DailyScrumExists(id))
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

        // POST: api/DailyScrums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DailyScrum>> PostDailyScrum(DailyScrum dailyScrum)
        {
          if (_context.DailyScrum == null)
          {
              return Problem("Entity set 'AppDbContext.DailyScrum'  is null.");
          }
            _context.DailyScrum.Add(dailyScrum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDailyScrum", new { id = dailyScrum.Id }, dailyScrum);
        }

        // DELETE: api/DailyScrums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDailyScrum(int id)
        {
            if (_context.DailyScrum == null)
            {
                return NotFound();
            }
            var dailyScrum = await _context.DailyScrum.FindAsync(id);
            if (dailyScrum == null)
            {
                return NotFound();
            }

            _context.DailyScrum.Remove(dailyScrum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DailyScrumExists(int id)
        {
            return (_context.DailyScrum?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
