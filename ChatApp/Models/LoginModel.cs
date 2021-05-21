using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Models
{
    public class LoginModel
    {
        [Required]
       
        public string korisnik_korisnicko_ime { get; set; }

        [Required]
        public string korisnik_sifra { get; set; }
    }
}
