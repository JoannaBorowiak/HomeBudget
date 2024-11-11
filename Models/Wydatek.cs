using System;
using System.ComponentModel.DataAnnotations; // <-- Ważne dla walidacji

namespace KalkulatorBudzetowy.Models
{
    public class Wydatek
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Kwota jest wymagana.")]
        [Range(0, double.MaxValue, ErrorMessage = "Kwota nie może być mniejsza niż 0.")]
        public decimal Kwota { get; set; }
        public DateTime Data { get; set; }
        public string Opis { get; set; }
        public int KategoriaId { get; set; }
        public Kategoria? Kategoria { get; set; } // Powiązanie z tabelą Kategorie
    }
}
