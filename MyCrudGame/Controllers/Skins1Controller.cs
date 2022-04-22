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
    public class Skins1Controller : ControllerBase
    {
        private readonly CRUDMyGameContext _context;

        public Skins1Controller(CRUDMyGameContext context)
        {
            _context = context;
        }

        // GET: api/Skins1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Skin>>> GetSkins()
        {
            return await _context.Skins.ToListAsync();
        }

        // GET: api/Skins1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Skin>> GetSkin(int id)
        {
            var skin = await _context.Skins.FindAsync(id);

            if (skin == null)
            {
                return NotFound();
            }

            return skin;
        }

        // PUT: api/Skins1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkin(int id, Skin skin)
        {
            if (id != skin.Id)
            {
                return BadRequest();
            }

            _context.Entry(skin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkinExists(id))
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

        // POST: api/Skins1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Skin>> PostSkin(Skin skin)
        {
            _context.Skins.Add(skin);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SkinExists(skin.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSkin", new { id = skin.Id }, skin);
        }

        // DELETE: api/Skins1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkin(int id)
        {
            var skin = await _context.Skins.FindAsync(id);
            if (skin == null)
            {
                return NotFound();
            }

            _context.Skins.Remove(skin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SkinExists(int id)
        {
            return _context.Skins.Any(e => e.Id == id);
        }
    }
}
