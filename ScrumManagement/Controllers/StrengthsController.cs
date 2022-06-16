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
    public class StrengthsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StrengthsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Strengths
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Strength>>> GetStrength()
        {
          if (_context.Strength == null)
          {
              return NotFound();
          }
            return await _context.Strength.ToListAsync();
        }

        // GET: api/Strengths/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Strength>> GetStrength(int id)
        {
          if (_context.Strength == null)
          {
              return NotFound();
          }
            var strength = await _context.Strength.FindAsync(id);

            if (strength == null)
            {
                return NotFound();
            }

            return strength;
        }

        // PUT: api/Strengths/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStrength(int id, Strength strength)
        {
            if (id != strength.Id)
            {
                return BadRequest();
            }

            _context.Entry(strength).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StrengthExists(id))
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

        // POST: api/Strengths
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Strength>> PostStrength(Strength strength)
        {
          if (_context.Strength == null)
          {
              return Problem("Entity set 'AppDbContext.Strength'  is null.");
          }
            _context.Strength.Add(strength);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStrength", new { id = strength.Id }, strength);
        }

        // DELETE: api/Strengths/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStrength(int id)
        {
            if (_context.Strength == null)
            {
                return NotFound();
            }
            var strength = await _context.Strength.FindAsync(id);
            if (strength == null)
            {
                return NotFound();
            }

            _context.Strength.Remove(strength);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StrengthExists(int id)
        {
            return (_context.Strength?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
