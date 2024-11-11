using System.ComponentModel.DataAnnotations;

namespace KalkulatorBudzetowy.Models
{
    public class Kategoria
    {
        public int Id { get; set; } // Klucz główny

        [Required]
        public string Nazwa { get; set; } // Nazwa kategorii, np. "Jedzenie", "Transport"
    }
}
