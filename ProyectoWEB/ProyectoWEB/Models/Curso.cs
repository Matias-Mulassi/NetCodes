using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoWEB.Models
{
    public class Curso
    {
        public Curso()
        {
            //Personas = new List<Persona2>();
            Personas= new List<Persona_Curso>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }

        //public virtual List<Persona2> Personas { get; set; }

        public virtual List<Persona_Curso> Personas {get; set;}
    }
}