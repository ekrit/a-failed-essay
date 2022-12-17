using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using seminarski.Data;
using seminarski.Modul_1.Models;
using seminarski.Modul_1.ViewModels;

namespace seminarski.Modul_1.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class KorisnikController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public KorisnikController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult getKorisnici()
        {
            return Ok(dbContext.Korisnici.ToList());
        }

        [HttpPost]
        public ActionResult addKorisnik([FromBody] addKorisnikVM x)
        {

            var novi = new Modul_1.Models.Korisnik()
            {
                isAdmin = false,
                ime = x.ime,
                prezime = x.prezime,
                email = x.email,
                lozinka = x.lozinka,
            };           

            dbContext.Korisnici.Add(novi);
            dbContext.SaveChanges();    

            return Ok(novi);
        }

        [HttpDelete]
        public ActionResult deleteKorisnik([FromHeader] int id)
        {
            var temp = dbContext.Korisnici.Find(id);

            if(temp != null)
            {
                dbContext.Remove(temp);
                dbContext.SaveChanges();

                return Ok(temp);
            }

            return Ok();
        }


    }
}
