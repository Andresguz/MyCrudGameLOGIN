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
    public class Ranks1Controller : ControllerBase
    {
        private readonly CRUDMyGameContext _context;

        public Ranks1Controller(CRUDMyGameContext context)
        {
            _context = context;
        }

        // GET: api/Ranks1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rank>>> GetRanks()
        {
            return await _context.Ranks.ToListAsync();
        }

        // GET: api/Ranks1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rank>> GetRank(int id)
        {
            var rank = await _context.Ranks.FindAsync(id);

            if (rank == null)
            {
                return NotFound();
            }

            return rank;
        }

        // PUT: api/Ranks1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRank(int id, Rank rank)
        {
            if (id != rank.Id)
            {
                return BadRequest();
            }

            _context.Entry(rank).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RankExists(id))
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

        // POST: api/Ranks1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rank>> PostRank(Rank rank)
        {
            _context.Ranks.Add(rank);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RankExists(rank.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRank", new { id = rank.Id }, rank);
        }

        // DELETE: api/Ranks1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRank(int id)
        {
            var rank = await _context.Ranks.FindAsync(id);
            if (rank == null)
            {
                return NotFound();
            }

            _context.Ranks.Remove(rank);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RankExists(int id)
        {
            return _context.Ranks.Any(e => e.Id == id);
        }
    }
}
