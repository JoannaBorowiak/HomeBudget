using System.ComponentModel.DataAnnotations;

namespace KalkulatorBudzetowy.Models
{
    public class Przychod
    {
        public int Id { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Kwota nie może być mniejsza niż 0.")]
        public decimal Kwota { get; set; }

        public DateTime Data { get; set; }

        [Required]
        public string Opis { get; set; }

        // Tylko KategoriaId jest wymagane
        [Required(ErrorMessage = "Kategoria jest wymagana.")]
        public int KategoriaId { get; set; }

        public Kategoria? Kategoria { get; set; }  // Kategoria - powiązanie obiektu
    }
}

