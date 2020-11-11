using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Faktura.Models
{
    public class Stavka
    {
        [Key]
        public int IdStavka { get; set; }
        public string OpisProdaneStavke { get; set; }
        public int KolicinaProdaneStavke { get; set; }
        public double CijenaStavkeBezPoreza { get; set; }
        public double UkupnaCijenaStavkaBezPoreza { get; set; } //(broj stavki(kolicina)*jedinicna cijena bez poreza)
       
        public int RacunId { get; set; }
        public Racun Racun { get; set; }
        
    }
}