using ProyectoWEB2.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProyectoWEB2.Controllers
{
    public class HomeController : Controller
    {
        private class NombreEdad 
        {
            public string Nombre { get; set; }
            public int Edad { get; set; }
        }


        public ActionResult Index(int? edad, int pagina = 1)
        {
            var cantidadRegistrosPorPagina = 5; // parámetro
            using (var db = new ApplicationDbContext())
            {
                Func<Personas, bool> predicado = x => !edad.HasValue || edad.Value == x.Edad;

                var personas = db.Personas.Where(predicado).OrderBy(x => x.Cedula)
                    .Skip((pagina - 1) * cantidadRegistrosPorPagina)
                    .Take(cantidadRegistrosPorPagina).ToList();
                var totalDeRegistros = db.Personas.Where(predicado).Count();

                var modelo = new IndexViewModel();
                modelo.Personas = personas;
                modelo.PaginaActual = pagina;
                modelo.TotalDeRegistros = totalDeRegistros;
                modelo.RegistrosPorPagina = cantidadRegistrosPorPagina;
                modelo.ValoresQueryString = new RouteValueDictionary(); //Se mantiene en el resto de las peticiones
                modelo.ValoresQueryString["edad"] = edad;

                return View(modelo);
            }

        }

            /* Paginador sin filtro
            public ActionResult Index(int pagina = 1) //Este parametro es en caso de que no se brinde una pagina
            {

                var cantidadRegistroPorPagina = 10; //Parametro. Aquí iria un parametro
                using (var db = new ApplicationDbContext())
                {
                    var personas = db.Personas.OrderBy(x => x.Cedula)
                        .Skip((pagina - 1) * cantidadRegistroPorPagina)
                        .Take(cantidadRegistroPorPagina).ToList();
                    var totalDeRegistros = db.Personas.Count(); //Para paginar el filtro al cual yo traje todos, lo debo aplicar aqui para contarlos

                    var modelo = new IndexViewModel();
                    modelo.Personas = personas;
                    modelo.PaginaActual = pagina;
                    modelo.TotalDeRegistros = totalDeRegistros;
                    modelo.RegistrosPorPagina = cantidadRegistroPorPagina;

                    return View(modelo);
                }

            /*

                    /*using (ApplicationDbContext db = new ApplicationDbContext())
                    {
                        //Este devuelve data
                        var personas= db.Database.SqlQuery<NombreEdad>("sp_Personas_Por_Edad @Edad", new SqlParameter("@Edad", 999)).ToList();

                        //correr procedimiento almacenado
                        //db.Database.ExecuteSqlCommand(RecursosSQL.sp_Borra_Personas_Menores_Nombre);
                    }

                    //return View();
            }

           */

            public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}