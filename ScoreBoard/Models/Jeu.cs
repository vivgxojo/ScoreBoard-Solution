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
        [JoueurExist] //Le message d'erreur est définit dans la classe JoueurExistAttribute
        public int JoueurId { get; set; } // Clé étrangère

        public Joueur? Joueur { get; set; } // Navigation (Nullable pour passer la validation)

        [Required]
        //Déclarer une règle de validation, qui peut être ensuite appliquée
        //côtés serveur et client
        [Range(0, 100, ErrorMessage = "Le score doit être entre 0 et 100.")]
        public int ScoreJoueur { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DateDansLePasse(ErrorMessage = "La date d’enregistrement doit être antérieure à aujourd’hui.")]
        public DateTime DateEnregistrement { get; set; }
    }
}
