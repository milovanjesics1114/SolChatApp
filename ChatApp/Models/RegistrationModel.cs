using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Unesite korisnicko ime")]
        [StringLength(100, MinimumLength = 3)]
        public string korisnik_korisnicko_ime { get; set; }

        [Display(Name="email")]
        [Required(ErrorMessage = "Email adresa je obavezna")]
        [EmailAddress(ErrorMessage = "Email adresa nije validna")]
        [StringLength(100)]
        public string korisnik_email { get; set; }

        [Required(ErrorMessage = "Unesite lozinku")]
        [StringLength(30, MinimumLength = 4)]
        public string korisnik_sifra { get; set; }

        public string ErrorMessage { get; set; }
    }
}
