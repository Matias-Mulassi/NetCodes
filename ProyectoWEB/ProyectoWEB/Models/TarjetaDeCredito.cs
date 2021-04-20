using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoWEB.Models
{
    public class TarjetaDeCredito
    {
        [Key]
        public string PAN { get; set; }
        public string NombreEnTarjeta { get; set; }
        public Persona2 Persona { get; set; }
    }
}