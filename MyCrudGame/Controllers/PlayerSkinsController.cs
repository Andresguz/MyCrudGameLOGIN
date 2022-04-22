using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyCrudGame.Data;
using MyCrudGame.Models;

namespace MyCrudGame.Controllers
{
    public class PlayerSkinsController : Controller
    {
        private readonly CRUDMyGameContext _context;

        public PlayerSkinsController(CRUDMyGameContext context)
        {
            _context = context;
        }

        // GET: PlayerSkins
        public async Task<IActionResult> Index()
        {
            var cRUDMyGameContext = _context.PlayerSkins.Include(p => p.Player).Include(p => p.Skin);
            return View(await cRUDMyGameContext.ToListAsync());
        }

        // GET: PlayerSkins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerSkin = await _context.PlayerSkins
                .Include(p => p.Player)
                .Include(p => p.Skin)
             
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playerSkin == null)
            {
                return NotFound();
            }

            return View(playerSkin);
        }

        // GET: PlayerSkins/Create
        public IActionResult Create()
        {
            ViewData["PlayerId"] = new SelectList(_context.Players, "Id", "Id");
            ViewData["SkinId"] = new SelectList(_context.Skins, "Id", "Id");
            return View();
        }

        // POST: PlayerSkins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerId,SkinId,Date,Id")] PlayerSkin playerSkin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playerSkin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlayerId"] = new SelectList(_context.Players, "Id", "Id", playerSkin.PlayerId);
            ViewData["SkinId"] = new SelectList(_context.Skins, "Id", "Id", playerSkin.SkinId);
            return View(playerSkin);
        }

        // GET: PlayerSkins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerSkin = await _context.PlayerSkins.FindAsync(id);
            if (playerSkin == null)
            {
                return NotFound();
            }
            ViewData["PlayerId"] = new SelectList(_context.Players, "Id", "Id", playerSkin.PlayerId);
            ViewData["SkinId"] = new SelectList(_context.Skins, "Id", "Id", playerSkin.SkinId);
            return View(playerSkin);
        }

        // POST: PlayerSkins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlayerId,SkinId,Date,Id")] PlayerSkin playerSkin)
        {
            if (id != playerSkin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playerSkin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerSkinExists(playerSkin.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlayerId"] = new SelectList(_context.Players, "Id", "Id", playerSkin.PlayerId);
            ViewData["SkinId"] = new SelectList(_context.Skins, "Id", "Id", playerSkin.SkinId);
            return View(playerSkin);
        }

        // GET: PlayerSkins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerSkin = await _context.PlayerSkins
                .Include(p => p.Player)
                .Include(p => p.Skin)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playerSkin == null)
            {
                return NotFound();
            }

            return View(playerSkin);
        }

        // POST: PlayerSkins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playerSkin = await _context.PlayerSkins.FindAsync(id);
            _context.PlayerSkins.Remove(playerSkin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerSkinExists(int id)
        {
            return _context.PlayerSkins.Any(e => e.Id == id);
        }
    }
}
