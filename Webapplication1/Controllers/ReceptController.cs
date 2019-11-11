using Kookboek.Models;
using Kookboek.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kookboek.Controllers
{
    public class ReceptController : Controller
    {
        private readonly IReceptenRepository ReceptenRepo;
        private readonly IGerechtIngrediëntenRepository GIRepo;
        private readonly IIngriediëntenRepository Irepo;

        public ReceptController(IReceptenRepository repo, IGerechtIngrediëntenRepository GIRepo, IIngriediëntenRepository Irepo)
        {
            this.ReceptenRepo = repo;
            this.GIRepo = GIRepo;
            this.Irepo = Irepo;
        }
        public IActionResult GetRecepten()
        {
            return View(ReceptenRepo.GetAllRecepten());
        }

        public IActionResult AddRecept()
        {
            var ing = GIRepo.AddIngrediënten();
            var recept = new ReceptModel();
            recept.Ingrediënten = ing;
            return View(recept);
        }

        [HttpPost]
        public IActionResult AddRecept(ReceptModel recept)
        {
            var newRecept = ReceptenRepo.AddGerecht(recept);
            Irepo.AddIngrediënt(newRecept);
            GIRepo.AddRecept(newRecept);
            return RedirectToAction("GetRecepten");
        }

        public IActionResult DeleteRecept(int gerechtID)
        {
            GIRepo.DeleteRecept(gerechtID);
            ReceptenRepo.DeleteRecept(gerechtID);
            return RedirectToAction("GetRecepten");
        }
    }
}
