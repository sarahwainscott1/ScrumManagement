using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScrumManagement.Models;

namespace ScrumManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StoriesController(AppDbContext context)
        {
            _context = context;
        }

        //recalculate sprint totals
        private async Task<ActionResult> CalculateSprintTotals(int storyid) {


            var sprintId = await (from st in _context.Stories
                            join sl in _context.SprintList on st.Id equals sl.StoryId
                            where sl.StoryId == storyid
                            select sl.SprintId).SingleAsync(); ;

            var sprint = await _context.Sprints.FindAsync(sprintId);

            if (sprint == null) { throw new Exception("No Sprint found"); }

            sprint.TotalTime = (from st in _context.Stories
                                join sl in _context.SprintList on st.Id equals sl.StoryId
                                where sl.SprintId == sprint.Id && sl.StoryId == storyid
                                select new {
                                    StoryTime = st.ActualTime
                                }).Sum(x => x.StoryTime);

            sprint.TotalPoints = (from st in _context.Stories
                                  join sl in _context.SprintList on st.Id equals sl.StoryId
                                  where sl.SprintId == sprint.Id && sl.StoryId == storyid
                                  select new {
                                      StoryPoints = st.EstimatedPoints
                                  }).Sum(x => x.StoryPoints);
            sprint.RemainingPoints = sprint.MaxPoints - sprint.TotalPoints;
            await _context.SaveChangesAsync();
            return Ok();
        }
        // GET: api/Stories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Story>>> GetStories()
        {
          if (_context.Stories == null)
          {
              return NotFound();
          }
            return await _context.Stories
                .Include(x => x.Product)
                .ToListAsync();
        }

        // GET: api/Stories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Story>> GetStory(int id)
        {
          if (_context.Stories == null)
          {
              return NotFound();
          }
            var story = await _context.Stories.Include(x => x.Product).SingleOrDefaultAsync(x => x.Id == id);

            if (story == null)
            {
                return NotFound();
            }

            return story;
        }
        //get by product
        [HttpGet("product/{productId}")]
        public async Task<ActionResult<IEnumerable<Story>>> GetStoriesByProduct(int productId) {
            if (_context.Stories == null) {
                return NotFound();
            }
            return await _context.Stories
                .Include(x => x.Product).Where(x => x.ProductId == productId)
                .ToListAsync();
        }
        //get by product without a sprint id
        private  Boolean CheckIfAssigned(int storyId, int productId) {

            var response = false;
            var story =  _context.Stories.FindAsync(storyId);

            var sprints = from st in _context.Stories
                          join p in _context.Products on st.ProductId equals p.Id
                          join sp in _context.Sprints on p.Id equals sp.ProductId
                          where st.ProductId == productId
                          select sp;

            foreach (var sprint in sprints) { 
                foreach(var list in sprint.SprintLists) {
                    if (list.StoryId == storyId) {
                        response = true;
                    }

                    
                }
            }
            return response;

        }
        [HttpGet("unassigned/{productId}/{sprintId}")]
        public async Task<ActionResult<IEnumerable<Story>>> GetUnAssigned(int productId,int sprintId) {
            if (_context.Stories == null) {
                throw new Exception("Not Found");
            }
            var stories = new List<Story>();
           var allStories = await _context.Stories
               .Where(x => x.ProductId == productId)
                .ToListAsync();
            if(allStories.Count == 0) { throw new Exception("No Stories on Product"); }

            var sprintLists = await _context.SprintList
                 .Where(x => x.SprintId == sprintId)
                 .ToListAsync();

            if(sprintLists.Count == 0) { return allStories; }

            foreach (var story in allStories) { 
               if(!sprintLists.Select(x => x.StoryId).Contains(story.Id)) {
                        stories.Add(story); 
                }
            }
       
            return stories;
        
        }

        // PUT: api/Stories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStory(int id, Story story)
        {
            if (id != story.Id)
            {
                return BadRequest();
            }

            _context.Entry(story).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                await CalculateSprintTotals(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoryExists(id))
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

        // POST: api/Stories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Story>> PostStory(Story story)
        {
          if (_context.Stories == null)
          {
              return Problem("Entity set 'AppDbContext.Stories'  is null.");
          }
            _context.Stories.Add(story);
            await _context.SaveChangesAsync();
            await CalculateSprintTotals(story.Id);

            return CreatedAtAction("GetStory", new { id = story.Id }, story);
        }

        // DELETE: api/Stories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStory(int id)
        {
            if (_context.Stories == null)
            {
                return NotFound();
            }
            var story = await _context.Stories.FindAsync(id);
            if (story == null)
            {
                return NotFound();
            }

            _context.Stories.Remove(story);
            await _context.SaveChangesAsync();
            await CalculateSprintTotals(id);

            return NoContent();
        }

        private bool StoryExists(int id)
        {
            return (_context.Stories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
