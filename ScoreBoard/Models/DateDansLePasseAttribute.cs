using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ScoreBoard.Models
{
    // Attribut de validation
    public class DateDansLePasseAttribute : ValidationAttribute, IClientModelValidator
    {
        //Définition d'une règle côté serveur
        public override bool IsValid(object value)
        {
            if (value is DateTime date)
            {
                return date <= DateTime.Now; //Inclure aujourd'hui
            }
            return false;
        }

        //Attacher à une règle JQuery côté client
        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-datedanslepasse", ErrorMessage ?? "La date doit être dans le passé.");
        }
    }
}
