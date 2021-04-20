using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoWEB.Models
{
    public class Persona_Curso
    {
        public string PersonaId { get; set; } //Es un string porque la PrimaryKey de persona es un string(Cedula)
        public int CursoId { get; set; }
        [ForeignKey("PersonaId")] //Acá indico que la clave foranea de persona es PersonaId
        public virtual Persona2 Persona { get; set; }
        public virtual Curso Curso { get; set; }

        public bool Abandonado { get; set; }



    }
}