using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kookboek.Models
{
    public class ReceptModel
    {
        public int GerechtId { get; set; }
        public string Gerecht { get; set; }
        public bool Vegetarisch { get; set; }
        public int Bereidingstijd { get; set; }
        public int AantalIngrediënten { get; set; }
        public string Foto { get; set; }
        public string Beschrijving { get; set; }
        public List<GerechtIngrediëntenModel> Ingrediënten { get; set; }
    }
}
