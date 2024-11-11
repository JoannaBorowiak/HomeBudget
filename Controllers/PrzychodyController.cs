using KalkulatorBudzetowy.Data;
using KalkulatorBudzetowy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KalkulatorBudzetowy.Controllers
{
    [Route("api/[controller]")]
[ApiController]
public class PrzychodyController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PrzychodyController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Endpoint do dodawania przychodu
    [HttpPost]
    public async Task<ActionResult<Przychod>> PostPrzychod([FromBody] Przychod przychod)
    {
        // Sprawdzamy, czy model jest prawidłowy
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);  // Zwracamy błędy walidacji, jeśli są
        }

        // Pobieramy kategorię na podstawie KategoriaId
        var kategoria = await _context.Kategorie.FindAsync(przychod.KategoriaId);

        if (kategoria == null)
        {
            return BadRequest("Kategoria o podanym ID nie istnieje.");
        }

        // Przypisujemy kategorię do transakcji
        przychod.Kategoria = kategoria;

        // Dodajemy przychód do bazy danych
        _context.Przychody.Add(przychod);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPrzychody), new { id = przychod.Id }, przychod);
    }

    // Endpoint do pobierania przychodów
    [HttpGet]
        public async Task<ActionResult<IEnumerable<Przychod>>> GetPrzychody()
        {
            var przychody = await _context.Przychody
                .Include(w => w.Kategoria)  // Eager loading: wczytanie powiązanej kategorii
                .ToListAsync();

            return Ok(przychody);
        }
}

}
