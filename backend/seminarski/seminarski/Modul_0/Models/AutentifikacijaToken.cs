using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using seminarski.Modul_1.Models;

namespace seminarski.Modul_0.Models
{
    public class AutentifikacijaToken
    {
        [Key]
        public int id { get; set; }
        public string vrijednost { get; set; }

        [ForeignKey(nameof(korisnik))]
        public int korisnikID { get; set; }
        public Korisnik korisnik { get; set; }
        public DateTime vrijemeEvidentiranja { get; set; }

    }
}
