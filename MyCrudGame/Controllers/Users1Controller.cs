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
    public class Users1Controller : ControllerBase
    {
        private readonly CRUDMyGameContext _context;

        public Users1Controller(CRUDMyGameContext context)
        {
            _context = context;
        }

        // GET: api/Users1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<User>> PostUser([FromForm] User user)
        //{
        //    _context.Users.Add(user);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetUser", new { id = user.Id }, user);
        //}

        //[HttpPost]
        //public async Task<ActionResult<User>> Authenticathe([FromForm] User user)
        //{
        //    //_context.Users.Add(user);
        //    using(var context = _context)
        //    {
        //        var userResult = await Task.Run(() => _context.Users.SingleOrDefault(x => x.Email == user.Email));
        //        if (userResult != null)
        //        {
        //            userResult.Email = user.Email;
        //            //return null;
        //        }
        //    }

        //    //var player = await _context.Players
        //    //    .Include(p => p.Ranks)
        //    //    .Include(p => p.IdNavigation)
        //    //    .Include(p => p.PlayerSkins)
        //    //    .ThenInclude(s => s.Skin)
        //    //    .FirstOrDefaultAsync(m => m.Id == userResp.Id);
        //    // await _context.SaveChangesAsync();

        //    return user;
        //}
        [HttpPost]
        public async Task<ActionResult<Player>> Authenpoticathe([FromForm] User user)
        {
            //using (var context = _context)
            //{
            //    var result = _context.Users.SingleOrDefault(x => x.Email == user.Email && x.Mnk == user.Mnk);
            //    if (result != null)
            //    {
            //        result.Email = user.Email;
            //        context.SaveChanges();
            //    }
            //    return Ok();
            //}
            var userResp = await Task.Run(() => _context.Users.SingleOrDefault(x => x.Email == user.Email && x.Mnk == user.Mnk));
            //var userResp = await Task.Run(() => _context.Users.SingleOrDefault(x => x.Email == user.Email));
            if (userResp == null)
            {
                return null;
            }
            else
            {

                var player = await _context.Players
                               .Include(p => p.Ranks)
                               .Include(p => p.IdNavigation)
                               .Include(p => p.PlayerSkins)
                               .ThenInclude(s => s.Skin)
                               .FirstOrDefaultAsync(m => m.Id == userResp.Id);
                return player;
            }

        }

        // DELETE: api/Users1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
