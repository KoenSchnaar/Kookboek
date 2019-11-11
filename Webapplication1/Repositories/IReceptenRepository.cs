using Kookboek.Models;
using System.Collections.Generic;

namespace Kookboek.Repositories
{
    public interface IReceptenRepository
    {
        ReceptModel AddGerecht(ReceptModel recept);
        public List<ReceptModel> GetAllRecepten();
        public void DeleteRecept(int gerechtID);
    }
}