using Microsoft.EntityFrameworkCore;
using seminarski.Modul_1.Models;

namespace seminarski.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Modul_1.Models.Korisnik> Korisnici { get; set; }
        public DbSet<Modul_0.Models.AutentifikacijaToken>  AutentifikacijaToken { get; set; }

    }
}
