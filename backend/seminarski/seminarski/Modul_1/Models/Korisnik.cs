using System.ComponentModel.DataAnnotations;

namespace seminarski.Modul_1.Models
{
    public class Korisnik
    {
        [Key]
        public int KorisnikID { get; set; }
        public string ime { get; set; }   
        public string prezime { get; set; } 
        public string email { get; set; }
        public string lozinka { get; set; } 
        public bool isAdmin { get; set; }

    }

}
