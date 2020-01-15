using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Find_a_Game.Models
{
    public class Gra
    {
        public int GraID { get; set; }

        [Required]
        [StringLength(250)]
        public string Nazwa { get; set; }

        [Required]
        public Gatunek Gatunek { get; set; }

        [Required]
        public Platforma Platforma { get; set; }

        [Required]
        [StringLength(250)]
        public string Producent { get; set; }

        [Required]
        [SprawdzRok]
        [Display(Name = "Rok Wydania")]
        public int RokWydania { get; set; }

        [Required]
        public string Ocena { get; set; }

        [StringLength(1000)]
        public string Opis { get; set; }
    }

    public class SprawdzRokAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int rok = (int)value;
            int biezrok = DateTime.Now.Year;

            if (rok < 1947 || rok > biezrok)
                return false;
            else
                return true;
        }
        public SprawdzRokAttribute()
        {
            ErrorMessage = "Prosze podac date miedzy latami 1947 a " + DateTime.Now.Year + ".";
        }
    }
}