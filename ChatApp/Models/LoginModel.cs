using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Unesite korisnicko ime")]
        public string korisnik_korisnicko_ime { get; set; }

        [Required(ErrorMessage = "Unesite lozinku")]
        public string korisnik_sifra { get; set; }

        public string ErrorMessage { get; set; }
    }
}
