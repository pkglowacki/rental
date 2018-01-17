using System.Collections.Generic;

namespace Rental.Models
{
    public class Urządzenie
    {
        public int Id { get; set; }
        public string NazwaUrządzenia { get; set; }
        public decimal MiesięcznyKosztWypożyczenia { get; set; }

        //Relacja
        public virtual ICollection<Zamówienie> Zamówienia { get; set; }

        public UrządzenieStatus Status { get; set; }
    }

    public enum UrządzenieStatus
    {
        Dostępne,
        Niedostępne
    };
}