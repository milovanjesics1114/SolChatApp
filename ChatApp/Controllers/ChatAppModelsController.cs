using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChatApp.Data;
using ChatApp.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using Microsoft.AspNetCore.SignalR;
using ChatApp.Hubs;

namespace ChatApp.Controllers
{
   

    public class ChatAppModelsController : Controller
    {
        /*PRIVATE CHAT OUTSITE HUB
        private IHubContext<ChatHub> _hubContext;

        public ChatAppModelsController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public IActionResult SendMessage(MessageModel model)
        {



            _hubContext.Clients.All.SendAsync("PrimljenaPoruka", model.sadrzaj);
            return PartialView("SubmitFormPartial");
        }
        /^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

        */

        private readonly MvcChatContext _context;

        public ChatAppModelsController(MvcChatContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index1()
        {
            return View();
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
        // GET: ChatAppModels/Login
       public IActionResult Login()
        {
            return View();
        } 

        // POST: ChatAppModels/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model_login)
        {
            if (ModelState.IsValid)
            {
                var userdetails = await _context.ChatAppModel.SingleOrDefaultAsync(m => m.korisnik_korisnicko_ime == model_login.korisnik_korisnicko_ime && m.korisnik_sifra == model_login.korisnik_sifra);
                
                if (userdetails == null)
                {
                    ModelState.AddModelError("Password", "Invalid login attempt.");
                    return View("Login");
                }
                HttpContext.Session.SetString("userName", userdetails.korisnik_korisnicko_ime);

            }
            else
            {
                return View("Index");
            }
            return RedirectToAction("Index");
        }
        //GET: ChatAppModels/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        private bool ChatAppModelExistsName(string user_name)
        {
            return _context.ChatAppModel.Any(e => e.korisnik_korisnicko_ime == user_name);
        }


        //REGISTER 
        [HttpPost]
        public async Task<ActionResult> Registration(RegistrationModel model)
        {

            if (ModelState.IsValid)
            {
                ChatAppModel user = new ChatAppModel
                {
                    korisnik_korisnicko_ime = model.korisnik_korisnicko_ime,
                    korisnik_email = model.korisnik_email,
                    korisnik_sifra = model.korisnik_sifra,
                   

                };
                _context.Add(user);
                await _context.SaveChangesAsync();

            }
            else
            {
                return View("Registration");
            }
            return RedirectToAction("Login", "ChatAppModels");
        }
        // registration Page load
        public IActionResult Registration()
        {
            ViewData["Message"] = "Registration Page";

            return View();
        }


        // GET: ChatAppModels/Chat
        /*public IActionResult Chat()
        {
            return View();
        }*/
        //CHECK
        public async Task<IActionResult> Chat(int? id) 
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Chat(int id)
        {
            //posebna metoda za linkovanje poruke s bazom
            //poziv te metode 
            return View();
        }

        public void ValidationMessage(string key, string alert, string value)
        {
            try
            {
                TempData.Remove(key);
                TempData.Add(key, value);
                TempData.Add("alertType", alert);
            }
            catch
            {
                Debug.WriteLine("TempDataMessage Error");
            }

        }

        //ajmoooo
        
    }
}
