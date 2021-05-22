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
        [Required]
        [StringLength(100)]
        public string korisnik_korisnicko_ime { get; set; }
        
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string korisnik_email { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 6)]
        public string korisnik_sifra { get; set; }
       
    }
}
