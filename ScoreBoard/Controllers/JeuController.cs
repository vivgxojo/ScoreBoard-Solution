using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScoreBoard.Models;

namespace ScoreBoard.Controllers
{
    public class JeuController : Controller
    {
        private readonly IJeuRepository _jeuRepository;
        //private readonly IJoueurRepository _joueurRepository;

        public JeuController(IJeuRepository jeuRepository)//, IJoueurRepository joueurRepository)
        {
            _jeuRepository = jeuRepository;
            //_joueurRepository = joueurRepository;
        }

        // GET: /Jeu
        public IActionResult Index()
        {
            var jeux = _jeuRepository.ListeJeux;
            return View(jeux);
        }

        // GET: /Jeu/Details/5
        public IActionResult Details(int id)
        {
            var jeu = _jeuRepository.GetJeu(id);
            if (jeu == null)
                return NotFound();

            return View(jeu);
        }

        // GET: /Jeu/Creer
        public IActionResult Creer()
        {
            //ViewBag.Joueurs = _joueurRepository.ListeJoueurs;
            return View();
        }

        // POST: /Jeu/Creer
        [HttpPost]
        public IActionResult Creer(Jeu jeu)
        {
            if (ModelState.IsValid) //Appliquer les règles de validation côté serveur
            {
                _jeuRepository.Ajouter(jeu); 
                return RedirectToAction("Index");
            }

            //ViewBag.Joueurs = _joueurRepository.ListeJoueurs;
            return View(jeu);
        }

        // GET: /Jeu/Modifier/5
        public IActionResult Modifier(int id)
        {
            var jeu = _jeuRepository.GetJeu(id);
            if (jeu == null)
                return NotFound();

            //ViewBag.Joueurs = _joueurRepository.ListeJoueurs;
            return View(jeu);
        }

        // POST: /Jeu/Modifier/5
        [HttpPost]
        public IActionResult Modifier(Jeu jeu)
        {
            if (ModelState.IsValid)
            {
                _jeuRepository.Modifier(jeu);
                return RedirectToAction("Index");
            }

            //ViewBag.Joueurs = _joueurRepository.ListeJoueurs;
            return View(jeu);
        }

        // GET: /Jeu/Supprimer/5
        public IActionResult Supprimer(int id)
        {
            var jeu = _jeuRepository.GetJeu(id);
            if (jeu == null)
                return NotFound();

            return View(jeu);
        }

        // POST: /Jeu/ConfirmerSuppression/5
        [HttpPost, ActionName("ConfirmerSuppression")]
        public IActionResult ConfirmerSuppressionPost(int id)
        {
            _jeuRepository.Supprimer(id);
            return RedirectToAction("Index");
        }
    }
}
