using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ChatApp.Models
{
    public class ChatAppModel
    {
        [Key]
        public int korisnikID { get; set; }
        public string korisnik_ime { get; set; }
        public string korisnik_korisnicko_ime { get; set; }

        public string korisnik_sifra { get; set; }
        public string korisnik_email { get; set; }

        public string korisnik_logo { get; set; }
        public bool korisnik_status { get; set; }
    }
}
