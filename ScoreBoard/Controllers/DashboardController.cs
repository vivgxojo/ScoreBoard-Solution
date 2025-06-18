using Microsoft.AspNetCore.Mvc;
using ScoreBoard.Models;
using ScoreBoard.ViewModels;

namespace ScoreBoard.Controllers
{
    public class DashboardController : Controller
    {

        private readonly IJoueurRepository _joueurRepository;

        public DashboardController(IJoueurRepository joueurRepository)
        {
            _joueurRepository = joueurRepository;
        }

        public IActionResult Index()
        {
            var joueurs = _joueurRepository.ListeJoueurs;
            var liste = new List<DashboardViewModel>();

            foreach (var joueur in joueurs)
            {
                liste.Add(new DashboardViewModel() { 
                    Joueur = joueur,
                    ScoreTotal = joueur.Jeux?.Sum(jeu => jeu.ScoreJoueur) ?? 0
                });
            }

            return View(liste);
        }
    }
}
