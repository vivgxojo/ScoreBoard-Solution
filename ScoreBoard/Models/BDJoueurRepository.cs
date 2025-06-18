using Microsoft.EntityFrameworkCore;

namespace ScoreBoard.Models
{
    public class BDJoueurRepository : IJoueurRepository
    {
        private readonly ScoresDBContext _context;

        public List<Joueur> ListeJoueurs { get; set; } = new();

        public BDJoueurRepository(ScoresDBContext context)
        {
            _context = context;
            ChargerListe();
        }

        private void ChargerListe()
        {
            ListeJoueurs = _context.Joueurs
                .Include(j => j.Jeux) // Si tu veux charger aussi les jeux liés
                .ToList();
        }

        public Joueur? GetJoueur(int id)
        {
            return ListeJoueurs.FirstOrDefault(j => j.Id == id);
        }

        public void Modifier(Joueur joueur)
        {
            var joueurExistant = _context.Joueurs.FirstOrDefault(j => j.Id == joueur.Id);
            if (joueurExistant != null)
            {
                joueurExistant.Nom = joueur.Nom;
                joueurExistant.Prenom = joueur.Prenom;
                joueurExistant.Equipe = joueur.Equipe;
                joueurExistant.Telephone = joueur.Telephone;
                joueurExistant.Courriel = joueur.Courriel;

                _context.SaveChanges();
                ChargerListe(); // Mettre à jour la liste en mémoire
            }
        }

        public void Supprimer(int id)
        {
            var joueur = _context.Joueurs.FirstOrDefault(j => j.Id == id);
            if (joueur != null)
            {
                _context.Joueurs.Remove(joueur);
                _context.SaveChanges();
                ChargerListe();
            }
        }
    }
}
