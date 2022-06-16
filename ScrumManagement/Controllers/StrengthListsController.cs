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
    public class StrengthListsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StrengthListsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/StrengthLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StrengthList>>> GetStrengthList()
        {
          if (_context.StrengthList == null)
          {
              return NotFound();
          }
            return await _context.StrengthList.Include(x => x.Strength).ToListAsync();
        }

        // GET: api/StrengthLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StrengthList>> GetStrengthList(int id)
        {
          if (_context.StrengthList == null)
          {
              return NotFound();
          }
            var strengthList = await _context.StrengthList.Include(x => x.Strength).SingleOrDefaultAsync(x => x.Id == id);

            if (strengthList == null)
            {
                return NotFound();
            }

            return strengthList;
        }

        // PUT: api/StrengthLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStrengthList(int id, StrengthList strengthList)
        {
            if (id != strengthList.Id)
            {
                return BadRequest();
            }

            _context.Entry(strengthList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StrengthListExists(id))
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

        // POST: api/StrengthLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StrengthList>> PostStrengthList(StrengthList strengthList)
        {
          if (_context.StrengthList == null)
          {
              return Problem("Entity set 'AppDbContext.StrengthList'  is null.");
          }
            _context.StrengthList.Add(strengthList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStrengthList", new { id = strengthList.Id }, strengthList);
        }

        // DELETE: api/StrengthLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStrengthList(int id)
        {
            if (_context.StrengthList == null)
            {
                return NotFound();
            }
            var strengthList = await _context.StrengthList.FindAsync(id);
            if (strengthList == null)
            {
                return NotFound();
            }

            _context.StrengthList.Remove(strengthList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StrengthListExists(int id)
        {
            return (_context.StrengthList?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
