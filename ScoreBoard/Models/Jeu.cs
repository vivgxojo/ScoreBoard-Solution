using System.ComponentModel.DataAnnotations;

namespace ScoreBoard.Models
{
    public class Jeu
    {
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DateDansLePasse(ErrorMessage = "La date de sortie doit être antérieure à aujourd’hui.")]
        public DateTime DateSortie { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Le joueur doit exister.")]
        public int JoueurId { get; set; }

        public Joueur Joueur { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Le score doit être entre 0 et 100.")]
        public int ScoreJoueur { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DateDansLePasse(ErrorMessage = "La date d’enregistrement doit être antérieure à aujourd’hui.")]
        public DateTime DateEnregistrement { get; set; }
    }
}
