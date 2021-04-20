using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Pelicula
    {

        public int Id { get; set; }
        [Required] //Se obliga a que este atributo no esté vacio a la hora de cargar la base de datos
        public string Titulo { get; set; }
        
        public int Duracion { get; set; }
        public DateTime Publicacion { get; set; }
        public string Pais { get; set; }

        public bool EstaEnCartelera { get; set; }
        [StringLength(120)] //Se define la longitud del string a insertar
        public string Genero { get; set; }
    }
}