using KalkulatorBudzetowy.Data;
using KalkulatorBudzetowy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KalkulatorBudzetowy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategorieController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public KategorieController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Endpoint do pobierania wszystkich kategorii
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kategoria>>> GetKategorie()
        {
            var kategorie = await _context.Kategorie.ToListAsync();
            return Ok(kategorie);  // Zwraca listę kategorii
        }
    }
}
