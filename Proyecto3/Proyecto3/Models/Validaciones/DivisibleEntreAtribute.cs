using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto3.Models.Validaciones
{
    public class DivisibleEntreAtribute : ValidationAttribute //La clase o atributo a ser validada, debe heredar de ValidationAttribute
    {
        private int _dividendo;

        public DivisibleEntreAtribute(int dividendo) //Se crea un constructor y especificamos mensaje de error
            :base("El campo {0} es invalido")
        {
            _dividendo = dividendo;
        
        }

        protected override ValidationResult IsValid(Object value, ValidationContext validationContext)
        {
            if (value != null) //Aquí se valida si es nulo. Si lo es, dejamos correr la validacion del Frontend
            {
                if ((int)value % _dividendo != 0)
                {
                    var mensajeDeError = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(mensajeDeError);
                }
            }

            return ValidationResult.Success;
        }


    }
}