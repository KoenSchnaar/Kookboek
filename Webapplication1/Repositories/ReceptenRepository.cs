using Kookboek.Converteer;
using Kookboek.Models;
using KookboekDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kookboek.Repositories
{
    public class ReceptenRepository : IReceptenRepository
    {
        private readonly KookboekContext context;
        ConvertRecept converteerder = new ConvertRecept();


        public ReceptenRepository(KookboekContext context)
        {
            this.context = context;
        }

        public List<ReceptModel> GetAllRecepten()
        {
            return context.Gerechtens.ToList().Select(g => converteerder.Converteer(g))
                .ToList();
        }

        public ReceptModel AddGerecht(ReceptModel recept)
        {
            var newGerecht = new Gerechten
            {
                Gerecht = recept.Gerecht,
                Bereidingstijd = recept.Bereidingstijd,
                Beschrijving = recept.Beschrijving,
                Vegetarisch = recept.Vegetarisch
            };
            context.Gerechtens.Add(newGerecht);
            context.SaveChanges();
            recept.GerechtId = newGerecht.GerechtId;
            return recept;
        }

        public void DeleteRecept(int gerechtID)
        {
            var entity = context.Gerechtens.Single(g => g.GerechtId == gerechtID);
            context.Gerechtens.Remove(entity);
            context.SaveChanges();
        }
    }
}
