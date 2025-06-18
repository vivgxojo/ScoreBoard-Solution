using Microsoft.AspNetCore.Mvc;
using ScoreBoard.Models;

namespace ScoreBoard.Controllers
{
    public class JoueurController : Controller
    {
        private readonly IJoueurRepository _joueursRep;

        public JoueurController(IJoueurRepository repo)
        {
            _joueursRep = repo;
        }

        public IActionResult Index()
        {
            return View(_joueursRep.ListeJoueurs);
        }

        [HttpGet]
        public IActionResult Modifier(int id)
        {
            var joueur = _joueursRep.GetJoueur(id);
            if (joueur == null)
                return NotFound();

            return View(joueur);
        }

        [HttpPost]
        public IActionResult Modifier(Joueur joueur)
        {
            if (ModelState.IsValid)
            {
                _joueursRep.Modifier(joueur);
                return RedirectToAction("Index");
            }

            return View(joueur);
        }

        [HttpGet]
        public IActionResult Supprimer(int id)
        {
            var joueur = _joueursRep.GetJoueur(id);
            if (joueur == null)
                return NotFound();

            return View(joueur);
        }

        public IActionResult SupprimerConfirme(int id)
        {
            _joueursRep.Supprimer(id);
            return RedirectToAction("Index");
        }
    }
}
