using Kookboek.Models;
using KookboekDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kookboek.Repositories
{
    public class IngriediëntenRepository : IIngriediëntenRepository
    {
        private readonly KookboekContext context;

        public IngriediëntenRepository(KookboekContext context)
        {
            this.context = context;
        }
        public void AddIngrediënt(ReceptModel recept) 
        {
            foreach (var ingr in recept.Ingrediënten)
            {
                var bestaat = context.Ingrediëntens.Count(i => i.Ingrediënt == ingr.Ingrediënt); // hier kan het fout gaan, moet eigenlijk met een boolean
                if (ingr.Ingrediënt != null && bestaat == 0)
                {
                    var newIngrediënt = new Ingrediënten
                    {
                        Ingrediënt = ingr.Ingrediënt
                    };
                    context.Ingrediëntens.Add(newIngrediënt);
                }
            }
            context.SaveChanges();
        }
    }
}
