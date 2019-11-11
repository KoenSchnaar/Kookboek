using Kookboek.Models;
using KookboekDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kookboek.Repositories
{
    public class GerechtIngrediëntenRepository : IGerechtIngrediëntenRepository
    {
        private readonly KookboekContext context;

        public GerechtIngrediëntenRepository(KookboekContext context)
        {
            this.context = context;
        }
        public List<GerechtIngrediëntenModel> AddIngrediënten()
        {
            var result = new List<GerechtIngrediëntenModel>();
            for (int i = 0; i < 2; i++)
            {
                result.Add(new GerechtIngrediëntenModel { Ingrediënt = "", Eenheid = "" }) ;
            }
            return result;
        }

        public void AddRecept(ReceptModel recept)
        {
            foreach (var ingr in recept.Ingrediënten)
            {
                if(ingr.Ingrediënt != null)
                {
                    var entity = context.Ingrediëntens.Single(i => i.Ingrediënt == ingr.Ingrediënt);
                    var newGerechtIngrediënt = new GerechtIngrediënt
                    {
                        GerechtId = recept.GerechtId,
                        IngrediëntId = entity.IngrediëntId,
                        Hoeveelheid = ingr.Hoeveelheid,
                        Eenheid = ingr.Eenheid
                    };
                    context.GerechtIngrediënts.Add(newGerechtIngrediënt);
                }
            }
            context.SaveChanges();
        }

        public void DeleteRecept(int gerechtID)
        {
            var entities = context.GerechtIngrediënts.Where(g => g.GerechtId == gerechtID).ToList();
            foreach(var entity in entities)
            {
                context.GerechtIngrediënts.Remove(entity);
            }
            context.SaveChanges();
        }
    }
}
