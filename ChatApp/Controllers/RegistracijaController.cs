using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Controllers
{
    public class RegistracijaController : Controller
    {
        [HttpGet]
        public ViewResult Register()
        {
           

            return View();

        }
        [HttpPost]
        public IActionResult Register(RegistracijaViewModel model)
        {
            return View();
        }
    }
 
   
    public class RegistracijaViewModel
    {
        [Required, MaxLength(100)]
        public string korisnik_korisnicko_ime { get; set; }

        [Required, MaxLength(100)]
        public string korisnik_ime { get; set; }

        [Required, MaxLength(30), DataType(DataType.Password)]
        public string korisnik_sifra { get; set; }

        [DataType(DataType.Password), Compare(nameof(korisnik_sifra))]
        public string potvrda_sifre { get; set; }

        [Required, MaxLength(100)]

        public string korisnik_email { get; set; }

       
    }

 
   
}
