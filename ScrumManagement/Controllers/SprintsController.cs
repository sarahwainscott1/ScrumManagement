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

    public class SprintsController : ControllerBase
    {
        private readonly AppDbContext _context;

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
