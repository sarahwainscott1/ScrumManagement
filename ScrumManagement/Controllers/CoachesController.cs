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
    public class CoachesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CoachesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Coaches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coach>>> GetCoaches()
        {
          if (_context.Coaches == null)
          {
              return NotFound();
          }
            return await _context.Coaches.Include(x => x.TeamMember).ToListAsync();
        }

        // GET: api/Coaches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coach>> GetCoach(int id)
        {
          if (_context.Coaches == null)
          {
              return NotFound();
          }
            var coach = await _context.Coaches.Include(x => x.TeamMember).SingleOrDefaultAsync(x => x.Id == id);

            if (coach == null)
            {
                return NotFound();
            }

            return coach;
        }

        // PUT: api/Coaches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoach(int id, Coach coach)
        {
            if (id != coach.Id)
            {
                return BadRequest();
            }

            _context.Entry(coach).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoachExists(id))
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

        // POST: api/Coaches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Coach>> PostCoach(Coach coach)
        {
          if (_context.Coaches == null)
          {
              return Problem("Entity set 'AppDbContext.Coaches'  is null.");
          }
            _context.Coaches.Add(coach);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoach", new { id = coach.Id }, coach);
        }

        // DELETE: api/Coaches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoach(int id)
        {
            if (_context.Coaches == null)
            {
                return NotFound();
            }
            var coach = await _context.Coaches.FindAsync(id);
            if (coach == null)
            {
                return NotFound();
            }

            _context.Coaches.Remove(coach);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoachExists(int id)
        {
            return (_context.Coaches?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
