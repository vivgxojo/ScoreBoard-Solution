using Microsoft.EntityFrameworkCore;

namespace ScoreBoard.Models
{
    public class ScoresDBContext : DbContext
    {
        public ScoresDBContext(DbContextOptions<ScoresDBContext> options)
        : base(options)
        {
        }

        public DbSet<Joueur> Joueurs { get; set; }
        public DbSet<Jeu> Jeux { get; set; }
    }
}
