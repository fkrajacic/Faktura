using Faktura.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Faktura.Data
{
    public class FakturaContext:DbContext
    {
        public FakturaContext():base("DefaultConnection")
        {}
        public DbSet<Racun> Racuni { get; set; }
        public DbSet<Stavka> Stavke { get; set; }
    }
}