using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rental.Models
{
    public class Zamówienie
    {
        public int ZamówienieId { get; set; }
        [Required]
        public string Imie { get; set; }
        [Required]
        public string Nazwisko { get; set; }
        [Required]
        public string Ulica { get; set; }
        public int NumerDomu { get; set; }
        public int NumerMieszkania { get; set; }
        public int IlośćMiesięcyWypożyczenia { get; set; }
        [Column(TypeName = "money")]
        public decimal? KosztZamówienia { get; set; } 
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataZłożenia { get; set;}
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataZwrotu { get; set; }

        // Klucz Obcy
        public int UrządzenieId { get; set; }
        //Relacja
        public virtual Urządzenie Urządzenie { get; set; }

        public bool sprawdźDate()
        {
            if (this.DataZłożenia <= this.DataZwrotu && this.DataZłożenia >= DateTime.Now.Date && this.DataZwrotu >= DateTime.Now.Date)
            {
                return true;
            }
            return false;
        }

        public void całkowityKoszt(Urządzenie urządzenie)
        {
            if (this.IlośćMiesięcyWypożyczenia > 0)
            {
               this.KosztZamówienia = this.IlośćMiesięcyWypożyczenia * urządzenie.MiesięcznyKosztWypożyczenia;
            }         
        }

        public void dataZwrotu(int iloscMiesiecyWypozyczenia)
        {
            this.DataZwrotu = this.DataZłożenia.AddMonths(this.IlośćMiesięcyWypożyczenia);
        }

    }
}