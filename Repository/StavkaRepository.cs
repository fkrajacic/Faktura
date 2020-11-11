using Faktura.Data;
using Faktura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Faktura.Repository
{
    public class StavkaRepository : IstavkaRepository
    {
        public List<Stavka> GetStavka(int? id)
        {
            List<Stavka> stavkas = new List<Stavka>();
            FakturaContext c = new FakturaContext();
            foreach(var i in c.Stavke)
            {
                if(i.RacunId==id)
                {
                    stavkas.Add(i);
                }
            }


            return stavkas;
        }

        public double IzracunCijene(int kolicina, double cijena) => kolicina * cijena;
    }
}