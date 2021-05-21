using ChatApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Controllers
{ 
    //dodat ovaj kontroler -> njegov folder za Views
    public class ChatovanjeController : Controller
    {
        private readonly MvcChatContext _context;

        public ChatovanjeController(MvcChatContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index1()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Chat(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chatAppModel = await _context.ChatAppModel.FirstOrDefaultAsync(m => m.korisnikID == id);
            if (chatAppModel == null)
            {
                return NotFound();
            }

            return View(chatAppModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Chat()
        {
            //posebna metoda za linkovanje poruke s bazom
            //poziv te metode 
            return View();
        }
    }
}
