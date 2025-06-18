using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ScoreBoard.Models
{
    public class JoueurExistAttribute : ValidationAttribute//, IClientModelValidator
    {
        //Définition d'une règle côté serveur
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var bdContext = context.GetService<ScoresDBContext>();
            bool exist = bdContext.Joueurs.Any(j => j.Id == (int)value);
            if (!exist)
            {
                return new ValidationResult("Le joueur doit exister");
            }
            /*Joueur j;
            try
            {
                j = (Joueur)value;
            }
            catch (Exception ex)
            {
                return new ValidationResult("Le joueur doit exister");
            }*/
            return ValidationResult.Success;
        }

        //Attacher à une règle JQuery côté client
       /* public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-joueurexiste", ErrorMessage ?? "Le joueur doit exister.");
        }*/
    }
}
