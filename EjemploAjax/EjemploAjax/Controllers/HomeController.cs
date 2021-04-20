using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EjemploAjax.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

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


        public PartialViewResult SeccionPrueba()
        {

            var personas = new List<Persona>()
            {
                new Persona() { Nombre="Felipe", Edad=999 },
                new Persona() { Nombre="Claudia", Edad=44 },
                new Persona() { Nombre="Genesis", Edad=23 },
                new Persona() { Nombre="Pedro", Edad=76 },
            };


            return PartialView("_Prueba", personas); //Las vistas parciales llevan _
        }


        [HttpPost]
        public JsonResult Duplicador(int cantidad)
        {
            var duplicado = cantidad * 2;
            return Json(duplicado);
        
        
        }
        [HttpPost]
        public JsonResult CrearPersona(Persona persona)
        {
            //Utilizamos una clase base para todas nuestras comunicaciones para establecer un estandar.
            var resultado = new BaseRespuesta();

            try

            {
                if (persona.Edad < 18)
                {
                    throw new ApplicationException("La persona no puede ser menor de edad");
                }

                //Codigo para crear una persona...

                resultado.Mensaje = "Persona creada correctamente";
                resultado.Ok = true;
            }
            catch (Exception ex)
            {

                resultado.Ok = false;
                resultado.Mensaje = ex.Message;

            }

            return Json(resultado);
        }
    }

    public class Persona
    {
        public string Nombre { get; set; }

        public int Edad { get; set; }


    }

    public class BaseRespuesta
    {
        public bool Ok { get; set; }

        public string Mensaje { get; set; }

    }

}


