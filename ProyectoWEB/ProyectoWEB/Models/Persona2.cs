using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoWEB.Models
{
    public class Persona2
    {

        public Persona2()
        {
            //Cursos = new List<Curso>();
            Cursos= new List<Persona_Curso>();
        }

        public string Cedula { get; set; }
    
        public string Nombre { get; set; }
       
        public DateTime Nacimiento { get; set; }
       
        public int Edad { get; set; }

        public Sexo Sexo { get; set; }

        public decimal Salario { get; set; }
        [NotMapped]
        public string Resumen { get { return $"{Nombre}({Nacimiento.ToString("dd-MM-yyyy")})";} } //Esto me trae el nombre de la persona y su nacimiento

        public Direccion2 Direccion { get; set; }

        public virtual List<TarjetaDeCredito> Tarjetas { get; set; } //Propiedad navigacional
        //public virtual List<Curso> Cursos { get; set; }
        public virtual List<Persona_Curso> Cursos {get; set;}


    }
}