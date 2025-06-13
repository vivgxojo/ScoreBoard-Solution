using System.ComponentModel.DataAnnotations;

namespace ScoreBoard.Models
{
    public class Joueur
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Nom { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Prenom { get; set; }

        [RegularExpression(@"^[A-Z]{2,4}$", ErrorMessage = "L'équipe doit contenir entre 2 et 4 lettres majuscules.")]
        public string? Equipe { get; set; }

        [Phone]
        public string? Telephone { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@scoreboard\.ca$", ErrorMessage = "Le courriel doit être au format identifiant@scoreboard.ca")]
        public string Courriel { get; set; }

        public List<Jeu>? Jeux { get; set; }
    }
}
