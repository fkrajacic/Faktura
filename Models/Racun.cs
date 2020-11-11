using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace Faktura.Models
{
    public class Racun
    {
        [Key]
        public int BrojFakture { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime DateNow { get; set; }
        public DateTime DatumDospijeca { get; set; }
        public double UkupnaCijenaBezPoreza { get; set; }
        public double UkupnaCijenaSPorezom { get; set; }
        public string NazivPrimateljaRacuna { get; set; }
        public List<Stavka> stavke { get; set; }

    }
}