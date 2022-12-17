using Microsoft.AspNetCore.Mvc;
using seminarski.Data;
using seminarski.Modul_0.Models;
using seminarski.Modul_0.ViewModels;
using seminarski.Modul_1.Models;
using seminarski.Helper;
    

namespace seminarski.Modul_0.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AutentifikacijaController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public AutentifikacijaController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public AutentifikacijaToken Login([FromBody] LoginVM x)
        {
            string randomString = TokenGenerator.Generate(10);
            Korisnik logiraniKorisnik = dbContext.Korisnici.Where(k => k.email == x.email && k.lozinka == x.lozinka).SingleOrDefault();

            if (logiraniKorisnik == null)
            {
                return null;
            }

            var novi = new AutentifikacijaToken
            {
                vrijednost = randomString,
                vrijemeEvidentiranja = DateTime.Now,
                korisnik = logiraniKorisnik,
            };

            dbContext.Add(novi);
            dbContext.SaveChanges();

            return novi;
        }
    }
}
