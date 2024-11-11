using KalkulatorBudzetowy.Data;
using KalkulatorBudzetowy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KalkulatorBudzetowy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WydatkiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WydatkiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Endpoint do dodawania wydatków
        [HttpPost]
        public async Task<ActionResult<Wydatek>> PostWydatek([FromBody] Wydatek wydatek)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Pobieramy kategorię na podstawie KategoriaId
            var kategoria = await _context.Kategorie.FindAsync(wydatek.KategoriaId);

            if (kategoria == null)
            {
                return BadRequest("Kategoria o podanym ID nie istnieje.");
            }

            // Przypisujemy kategorię do transakcji
            wydatek.Kategoria = kategoria;

            _context.Wydatki.Add(wydatek);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWydatki), new { id = wydatek.Id }, wydatek);
        }

        // Endpoint do pobierania wszystkich wydatków
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wydatek>>> GetWydatki()
        {
            var wydatki = await _context.Wydatki
                .Include(w => w.Kategoria)  // Eager loading: wczytanie powiązanej kategorii
                .ToListAsync();

            return Ok(wydatki);
        }
    }

}
