using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApp.Models
{
    public class MessageModel
    {
        [Key]
        public int porukaID { get; set; }
        [Required]
        public string sadrzaj { get; set; }
        [Required]
        public DateTime vreme_poruke { get; set; }

        public int poruka_korisnikID { get; set; }
        public ChatAppModel ChatAppModel { get; set; }
  
    }
}
