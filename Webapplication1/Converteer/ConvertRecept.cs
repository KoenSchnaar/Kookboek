using Kookboek.Models;
using KookboekDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kookboek.Converteer
{
    public class ConvertRecept
    {
        public ReceptModel Converteer(Gerechten entity)
        {
            return new ReceptModel
            {
                GerechtId = entity.GerechtId,
                Gerecht = entity.Gerecht,
                Vegetarisch = entity.Vegetarisch,
                Bereidingstijd = entity.Bereidingstijd,
                AantalIngrediënten = entity.AantalIngrediënten,
                Foto = entity.Foto,
                Beschrijving = entity.Beschrijving
            };
        }
    }
}
