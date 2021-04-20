using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Services
{
    public class PeliculasService
    {
        public Pelicula ObtenerPelicula()
        {
            return new Pelicula()
            {
                Titulo = "Escape Plan",
                Duracion = 115,
                Publicacion = new DateTime(2013, 12, 15),
                Pais = "USA",
                Genero = "Acción",
                EstaEnCartelera = true

            };
        
        }

        public List<Pelicula> ObtenerPeliculas()

        {
            return new List<Pelicula>()
            {

            new Pelicula()
            {
                Titulo = "Escape Plan",
                Duracion = 115,
                Publicacion = new DateTime(2013, 12, 15),
                Pais = "USA",
                Genero = "Acción",
                EstaEnCartelera = true

            },

            new Pelicula()
            {
                Titulo = "Mechanic : resurrection",
                Duracion = 130,
                Publicacion = new DateTime(2016, 02, 15),
                Pais = "BLG",
                Genero = "Fantasia",
                EstaEnCartelera = false


            },
            new Pelicula()
            {
                Titulo = "Rocky 3",
                Duracion = 120,
                Publicacion = new DateTime(2013, 04, 15),
                Pais = "USA",
                Genero = "Deportes",
                EstaEnCartelera = true


            }


        };
            

        }
    }
}