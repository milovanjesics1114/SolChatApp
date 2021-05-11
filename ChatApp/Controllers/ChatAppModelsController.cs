using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChatApp.Data;
using ChatApp.Models;

namespace ChatApp.Controllers
{
    public class ChatAppModelsController : Controller
    {
        private readonly MvcChatContext _context;

        public ChatAppModelsController(MvcChatContext context)
        {
            _context = context;
        }

        // GET: ChatAppModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ChatAppModel.ToListAsync());
        }

        // GET: ChatAppModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chatAppModel = await _context.ChatAppModel
                .FirstOrDefaultAsync(m => m.korisnikID == id);
            if (chatAppModel == null)
            {
                return NotFound();
            }

            return View(chatAppModel);
        }

        // GET: ChatAppModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChatAppModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("korisnikID,korisnik_ime,korisnik_korisnicko_ime,korisnik_sifra,korisnik_email,korisnik_logo,korisnik_status")] ChatAppModel chatAppModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chatAppModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chatAppModel);
        }

        // GET: ChatAppModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chatAppModel = await _context.ChatAppModel.FindAsync(id);
            if (chatAppModel == null)
            {
                return NotFound();
            }
            return View(chatAppModel);
        }

        // POST: ChatAppModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("korisnikID,korisnik_ime,korisnik_korisnicko_ime,korisnik_sifra,korisnik_email,korisnik_logo,korisnik_status")] ChatAppModel chatAppModel)
        {
            if (id != chatAppModel.korisnikID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chatAppModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChatAppModelExists(chatAppModel.korisnikID))
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
            return View(chatAppModel);
        }

        // GET: ChatAppModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chatAppModel = await _context.ChatAppModel
                .FirstOrDefaultAsync(m => m.korisnikID == id);
            if (chatAppModel == null)
            {
                return NotFound();
            }

            return View(chatAppModel);
        }

        // POST: ChatAppModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chatAppModel = await _context.ChatAppModel.FindAsync(id);
            _context.ChatAppModel.Remove(chatAppModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChatAppModelExists(int id)
        {
            return _context.ChatAppModel.Any(e => e.korisnikID == id);
        }
    }
}
