using Microsoft.EntityFrameworkCore;
using KalkulatorBudzetowy.Models;

namespace KalkulatorBudzetowy.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Przychod> Przychody { get; set; }
        public DbSet<Wydatek> Wydatki { get; set; }
        public DbSet<Kategoria> Kategorie { get; set; }
    }
}
