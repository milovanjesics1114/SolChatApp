using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApp.Models
{
    public class ChatAppModel
    {
        [Key]
        public int korisnikID { get; set; }

        public string korisnik_ime { get; set; }

        [Display(Name = "Korisnicko ime")]
        [Required(ErrorMessage = "Korisnicko ime je obavezno.")]
        public string korisnik_korisnicko_ime { get; set; }
       
        [Display(Name = "Lozinka")]
        [Required(ErrorMessage = "Lozinka je obavezna.")]
        [DataType(DataType.Password)]
        public string korisnik_sifra { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email je obavezan.")]
        public string korisnik_email { get; set; }

        
        public string korisnik_logo { get; set; }
        public bool korisnik_status { get; set; }

     
        public List<MessageModel> MessageModel { get; set; } //or ICollection instead of List??
    }
    
}
