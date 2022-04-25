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
    public class PlayerSkins1Controller : ControllerBase
    {
        private readonly CRUDMyGameContext _context;

        public PlayerSkins1Controller(CRUDMyGameContext context)
        {
            _context = context;
        }

        // GET: api/PlayerSkins1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerSkin>>> GetPlayerSkins()
        {
            return await _context.PlayerSkins.ToListAsync();
            
        }

        // GET: api/PlayerSkins1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerSkin>> GetPlayerSkin(int id)
        {
            var playerSkin = await _context.PlayerSkins.
                FindAsync(id);

            if (playerSkin == null)
            {
                return NotFound();
            }

            return playerSkin;
        }

        // PUT: api/PlayerSkins1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerSkin(int id, PlayerSkin playerSkin)
        {
            if (id != playerSkin.Id)
            {
                return BadRequest();
            }

            _context.Entry(playerSkin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerSkinExists(id))
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

        // POST: api/PlayerSkins1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlayerSkin>> PostPlayerSkin([FromForm] PlayerSkin playerSkin)
        {
            _context.PlayerSkins.Add(playerSkin);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlayerSkinExists(playerSkin.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPlayerSkin", new { id = playerSkin.Id }, playerSkin);
        }

        // DELETE: api/PlayerSkins1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayerSkin(int id)
        {
            var playerSkin = await _context.PlayerSkins.FindAsync(id);
            if (playerSkin == null)
            {
                return NotFound();
            }

            _context.PlayerSkins.Remove(playerSkin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerSkinExists(int id)
        {
            return _context.PlayerSkins.Any(e => e.Id == id);
        }
    }
}
