using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoWEB.Models
{
    public class Direccion2
    {
        public int CodigoDireccion { get; set; }
        public string Calle { get; set; }

        public Persona2 Persona { get; set; }
    }
}