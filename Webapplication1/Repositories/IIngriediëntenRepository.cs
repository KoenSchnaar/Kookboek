using Kookboek.Models;

namespace Kookboek.Repositories
{
    public interface IIngriediëntenRepository
    {
        void AddIngrediënt(ReceptModel recept);
    }
}