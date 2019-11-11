using System;
using System.Collections.Generic;

namespace KookboekDB
{
    public partial class Gerechten
    {
        public int GerechtId { get; set; }
        public string Gerecht { get; set; }
        public bool Vegetarisch { get; set; }
        public int Bereidingstijd { get; set; }
        public int AantalIngrediënten { get; set; }
        public string Foto { get; set; }
        public string Beschrijving { get; set; }
    }
}