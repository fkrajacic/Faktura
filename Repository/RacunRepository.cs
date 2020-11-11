using Faktura.Models;
using Microsoft.Owin.Security.Provider;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Faktura.Repository
{
    public class RacunRepository : IRacunRepository
    {
        public DateTime GetTodayDate() => DateTime.Now;


        public string GetUser()
        {
            User ur = new User();
            return ur.Name;
        }
       
    }
}