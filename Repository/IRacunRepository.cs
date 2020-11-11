using Faktura.Models;
using Microsoft.VisualBasic;
using System;

namespace Faktura.Repository
{
    public interface IRacunRepository
    {
        string GetUser();
        DateTime GetTodayDate();
    }
}