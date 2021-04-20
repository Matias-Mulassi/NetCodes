using Proyecto.Models;
using Proyecto.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{

    public class Persona
    {
        public string Nombre { get; set; }

        public int Edad { get; set; }
        public bool Empleado{ get; set; }

        public  DateTime Nacimiento { get; set; }

    }



    public class HomeController : Controller
    {
        private PeliculasService _peliculasService1;

        public HomeController()
        {
            _peliculasService1 = new PeliculasService();
        
        }

        [HttpGet]
        public ActionResult Index() //Representan a la pagina, como un link
        {
            /*
            var persona1 = new Persona()
            {
                Nombre = "Matias",
                Edad = 14,
                Empleado=true,
                Nacimiento= new DateTime(2015,1,2)

            };
            ViewBag.Propiedad=persona1;
            ViewBag.Persona = persona1;

            */


            //return Redirect("https://google.com.do"); //Redireccionar. Se usa RedirectResult
            //return RedirectToAction("Register", "Account"); //Usa RedirectToRouteResult
            //return RedirectToRoute("Ejemplo");
            //var persona1 = new Persona() { Nombre = "Felipe", Edad = 99 };
            //var persona2 = new Persona() { Nombre = "Claudia", Edad = 90 };
            //return Json(new List<Persona>(){ persona1,persona2}, JsonRequestBehavior.AllowGet); //Permitir información de Json en un getRequest
            //return new HttpStatusCodeResult(404); Retornamos error. Se usa ActionResult
            //return Content("<b>Felipe</b>"); //Retornamos string libre.Puede ser HTML. Se requiere devolver un ContentResult


            //ViewBag.MiListado = ObtenerListado();
            //ViewBag.MiListadoEnum = ToListSelectListItem<ResultadoOperacion>();

            var personas = new List<Persona>()
            {
                new Persona()
                {
                    Nombre= "Henry",
                    Edad= 24,
                    Empleado=false,
                    Nacimiento= new DateTime(2/5/1996)
                },

                new Persona()
                {
                    Nombre= "Adam",
                    Edad= 30,
                    Empleado=true,
                    Nacimiento= new DateTime(2/5/1990)
                },

                new Persona()
                {
                    Nombre= "Vannesa",
                    Edad= 18,
                    Empleado=false,
                    Nacimiento= new DateTime(2/5/2003)
                },

            };

            ViewBag.MiListado = personas;

            return View();
        }

        [HttpPost]
        public ActionResult Index(Persona persona)
        {
            ViewBag.Message = "Exitoso";
            return View(persona); //Una vez lleno el objeto, se devuelve a la vista.
        }

        public List<SelectListItem> ToListSelectListItem<T>()
        {
            var t = typeof(T);

            if (!t.IsEnum) { throw new ApplicationException("Tipo debe ser enum"); }

            var members = t.GetFields(BindingFlags.Public | BindingFlags.Static);

            var result = new List<SelectListItem>();

            foreach (var member in members)
            {
                var attributeDescription = member.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute),
                    false);
                var descripcion = member.Name;

                if (attributeDescription.Any())
                {
                    descripcion = ((System.ComponentModel.DescriptionAttribute)attributeDescription[0]).Description;
                }

                var valor = ((int)Enum.Parse(t, member.Name));
                result.Add(new SelectListItem()
                {
                    Text = descripcion,
                    Value = valor.ToString()
                });
            }
            return result;
        }


        public List<SelectListItem> ObtenerListado()
        {

            return new List<SelectListItem>() //Vamos a añadir opciones del dropDownList
            {
                
                new  SelectListItem()
                {
                    Text = "Si",
                    Value = "1"
                },
                new SelectListItem()
                {
                Text="No",
                Value= "2",
                
                },

                new SelectListItem()
                {
                Text="Quizás",
                Value= "3",
                }

                };
            }

        //Con FileResult retornamos archivos. Con ViewResult se retornan vistas. 
        public ActionResult About() // A cada ActionResult le corresponde un view. Son clases que retornan diferentes tipos de salidas.
        {
            var personas = new List<Persona>()
            {
                new Persona()
                {
                    Nombre= "Henry",
                    Edad= 24,
                    Empleado=false,
                    Nacimiento= new DateTime(2/5/1996)
                },

                new Persona()
                {
                    Nombre= "Adam",
                    Edad= 30,
                    Empleado=true,
                    Nacimiento= new DateTime(2/5/1990)
                },

                new Persona()
                {
                    Nombre= "Vannesa",
                    Edad= 18,
                    Empleado=false,
                    Nacimiento= new DateTime(2/5/2003)
                },

            };

            ViewBag.MiListado = personas;
            ViewBag.Message = "Your application description page.";

            var peliculasService = new PeliculasService();
            var model = peliculasService.ObtenerPeliculas(); //aca la declaro como variable pero en vista poner que recibe lista

            return View(model);
        }

        [HttpGet] //Sirve para indicar que el metodo o action sera utilizado con METODO GET

        /*
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View("Contact"); //Le indico que vista quiero que retorne con ""
        }

        [HttpPost] //Sirve para indicar que el metodo o action sera utilizado con METODO POST

        public ActionResult Contact(int edad)
        {
            ViewBag.Message = "Your contact page."+ edad;

            return View("Contact"); //Le indico que vista quiero que retorne con ""
        }

        */

        [ChildActionOnly] //Para que solo pueda acceder por un RenderAction
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";// Objeto que permite enviar información desde el action a la vista
            //ViewBag.UnInt = 45;
            //ViewBag.UnaFecha = new DateTime(1800, 4, 7);
            //ViewData["Mi mensaje"] = "Esto fue realizado con ViewData";

            //return View("Contact"); //Le indico que vista quiero que retorne con "" Aqui podemos sobrecargar el metodo y enviar un modelo. Solo uno
            var model = _peliculasService1.ObtenerPeliculas();
            return View(model);

        }

        public ActionResult MiAction() 
        
        {
            return View();

        }
    }
}