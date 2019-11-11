using Kookboek.Models;
using System.Collections.Generic;

namespace Kookboek.Repositories
{
    public interface IGerechtIngrediëntenRepository
    {
        List<GerechtIngrediëntenModel> AddIngrediënten();
        public void AddRecept(ReceptModel recept);
        public void DeleteRecept(int gerechtID);
    }
}