using System;
using System.Collections.Generic;

namespace KookboekDB
{
    public partial class GerechtIngrediënt
    {
        public int GerechtIngrediëntId { get; set; }
        public int GerechtId { get; set; }
        public int IngrediëntId { get; set; }
        public string Hoeveelheid { get; set; }
        public string Eenheid { get; set; }
    }
}