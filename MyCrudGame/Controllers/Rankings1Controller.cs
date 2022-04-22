using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCrudGame.Data;
using MyCrudGame.Models;

namespace MyCrudGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Rankings1Controller : ControllerBase
    {
        private readonly CRUDMyGameContext _context;

        public Rankings1Controller(CRUDMyGameContext context)
        {
            _context = context;
        }

        // GET: api/Rankings1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ranking>>> GetRanking()
        {
            return await _context.Ranking.ToListAsync();
        }

        // GET: api/Rankings1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ranking>> GetRanking(int id)
        {
            var ranking = await _context.Ranking.FindAsync(id);

            if (ranking == null)
            {
                return NotFound();
            }

            return ranking;
        }

        // PUT: api/Rankings1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRanking(int id, Ranking ranking)
        {
            if (id != ranking.Id)
            {
                return BadRequest();
            }

            _context.Entry(ranking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RankingExists(id))
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

        // POST: api/Rankings1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ranking>> PostRanking(Ranking ranking)
        {
            _context.Ranking.Add(ranking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRanking", new { id = ranking.Id }, ranking);
        }

        // DELETE: api/Rankings1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRanking(int id)
        {
            var ranking = await _context.Ranking.FindAsync(id);
            if (ranking == null)
            {
                return NotFound();
            }

            _context.Ranking.Remove(ranking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RankingExists(int id)
        {
            return _context.Ranking.Any(e => e.Id == id);
        }
    }
}
