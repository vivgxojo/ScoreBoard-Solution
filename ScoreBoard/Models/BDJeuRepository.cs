using Microsoft.EntityFrameworkCore;

namespace ScoreBoard.Models
{
    public class BDJeuRepository : IJeuRepository
    {
        private readonly ScoresDBContext _context;

        public List<Jeu> ListeJeux  => _context.Jeux
                .Include(j => j.Joueur) // pour charger aussi les infos du joueur associé
                .ToList();

        public BDJeuRepository(ScoresDBContext context)
        {
            _context = context;
        }

        public Jeu? GetJeu(int id)
        {
            return ListeJeux.FirstOrDefault(j => j.Id == id);
        }

        public void Ajouter(Jeu jeu)
        {
            _context.Jeux.Add(jeu);
            _context.SaveChanges();
        }

        public void Modifier(Jeu jeu)
        {
            _context.Jeux.Update(jeu);
            _context.SaveChanges();
        }

        public void Supprimer(int id)
        {
            var jeu = _context.Jeux.FirstOrDefault(j => j.Id == id);
            if (jeu != null)
            {
                _context.Jeux.Remove(jeu);
                _context.SaveChanges();
            }
        }
    }
}
