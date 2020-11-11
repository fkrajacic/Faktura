using Faktura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faktura.Repository
{
    public interface IstavkaRepository
    {
         double IzracunCijene(int kolicina, double cijena);
        List<Stavka> GetStavka(int? id);
    }
}
