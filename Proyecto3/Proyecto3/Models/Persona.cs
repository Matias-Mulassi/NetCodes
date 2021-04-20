using Proyecto3.Models.Validaciones;
using Recursos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto3.Models
{
    public class Persona : IValidatableObject //Hacemos validaciones desde el modelo
    {

        public int Id { get; set; }
        [Required(ErrorMessageResourceType =typeof(Recurso),ErrorMessageResourceName = "Mensaje_Error_Required")] //Personalizacion de mensajes segun idioma recurso
        [Display(ResourceType =typeof(Recurso),Name = "Persona_Nombre_Texto_Mostrar")] //Aclaramos que este display posee un recurso multiIdioma
        public string Nombre { get; set; }
        [Display(Name ="Código Postal")] //Doy formato al label text
        [StringLength(6, MinimumLength =5, ErrorMessage ="El campo {0} debe tener una longitud minima de {2} y una longitud maxima de {1}")] //Definimos longitudes
        public string CodigoPostal { get; set; }
        [Range(18,100,ErrorMessage ="La {0} minima es {1} y la edad maxima es {2}")]
        public int Edad { get; set; }

        [StringLength(200)]
        public string Email { get; set; }
        [NotMapped] //Se indica que no queremos que esta propiedad sea mapeada por la base de datos
        [System.ComponentModel.DataAnnotations.Compare("Email",ErrorMessage ="Los Emails no concuerdan")] //Compara de que ambos campos sean iguales
        public string ConfirmarEmail { get; set; }
        [CreditCard(ErrorMessage ="Tarjeta Invalida")] //Validamos la tarjeta de credito del usuario
        public string TarjetaDeCredito { get; set; }

        //[Remote("DivisibleEntre2","Personas",ErrorMessage ="El numero debe ser divisible entre 2")] //Para crear validaciones con Remote
        [DivisibleEntreAtribute(2,ErrorMessage ="El valor del campo {0} no es divisible entre 2")] //Validacion personalizada
        public int NumeroDivisibleEntre2 { get; set; }

        public decimal Salario { get; set; }

        public decimal MontoSolicitudPrestamo { get; set; }

        [NotMapped]
        [ScaffoldColumn(false)] //No va a formar parte de la vista. POR DEFECTO ES TRUE

        public string CampoSecreto { get; set; }
        [DataType(DataType.Password)] //Definimos el tipo de dato para la vista
        public string Resumen { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errores = new List<ValidationResult>();
            if (Salario * 4 < MontoSolicitudPrestamo)
            {
                errores.Add(new ValidationResult("El monto de solicitud de prestamo no debe exceder 4 veces el salario",
                    new string[] { "MontoSolicitudPrestamo" })); //1er parametro mensaje de error, 2do arreglo con propiedad que dieron error 
            
            }
            return errores;
        }
    }
}