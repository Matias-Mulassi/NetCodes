using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoWEB.Models;

namespace ProyectoWEB.Controllers
{
    public class PersonasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        class Estadistica 
        {
            public Sexo Sexo { get; set; }
            public int Cantidad { get; set; }
        }

        // GET: Personas
        public ActionResult Index()
        {

            /*
            //PROBLEMA N+1 DIFERENCIAS ENTRE LAZY LOADING Y EAGER LOADING

            //LAZY LOADING TARDA MUCHISIMO, PORQUE HACE VARIAS CONSULTAS, 15 MIL +1
            var inicioLazyLoading = DateTime.Now;
            var personasLazy = db.Persona.Take(15000).ToList();

            foreach (var persona in personasLazy)
            {
                var calle = persona.Direcciones[0].Calle;
            }

            var finLazyLoading = DateTime.Now;


            //EAGER LOADING TARDA MENOS, PORQUE SOLO REALIZA UNA CONSULTA NOMAS.
            var inicioEagerLoading = DateTime.Now;
            var personas = db.Persona.Include(x => x.Direcciones).ToList();

            foreach (var persona in personas)
            {
                var calle = persona.Direcciones[0].Calle;
            }

            var finEagerLoading = DateTime.Now;

            */
            
            /* LAZY LOADING
            //Traer una persona con sus direcciones
            var persona = db.Persona.FirstOrDefault();
            var primeraDireccion = persona.Direcciones[0];

            //Traer todas las personas con sus direcciones.
            var personasConDirecciones = db.Persona.ToList();
            var direccionSegundaPersona = personasConDirecciones[1].Direcciones[0];

            //Segundo Nivel
            var subCalle = persona.Direcciones[0].SubDireccion[0].SubCalle;

            //Un problema: Serializacion
            var personaJSON = Newtonsoft.Json.JsonConvert.SerializeObject(persona);

            */
            
            /*
            //EAGER LOADING
            var persona = db.Persona.FirstOrDefault();


            // Error: Debemos utilizar Include
            var primeraDireccion = persona.Direcciones[0];

            //Include con Lambda
            var personaInclude = db.Persona.Include(x => x.Direcciones).FirstOrDefault();
            var primeraDireccionInclude = persona.Direcciones[0];

            //Include con String
            var personaConDirecciones = db.Persona.Include("Direcciones").ToList();
            var direccionDeLaSegundaPersona = personaConDirecciones[1].Direcciones[0];

            //Include segundo nivel
            var personasConDireccionesConSub = db.Persona.Include(x => x.Direcciones.Select(y => y.SubDireccion)).FirstOrDefault();
            var subCalle = personasConDireccionesConSub.Direcciones[0].SubDireccion[0].SubCalle;

            */
            
            /* 
            //SQL QUERY.

            var personas = db.Persona.SqlQuery("SELECT * FROM dbo.Personas").ToList();

            var direccion = db.Database.SqlQuery<Direccion>(
                @"SELECT *
                    FROM dbo.Direccions
                    Where CodigoDireccion = @Id", new SqlParameter("@Id", 2)).FirstOrDefault();


            //En el siguiente codigo, al crear una propia estructura, debimos crear la clase estadistica

            var estadisticaDeSexo = db.Database.SqlQuery<Estadistica>(
                @"SELECT Sexo, count (*) as Cantidad
                    from dbo.Personas
                    GROUP BY Sexo").ToList();

            */

            //VER QUERY GENERADA POR ENTITY FRAMEWORK
            //var personas = db.Persona.ToString(); //El toString() te guarda la query que entity framework genera

            //var direccion = db.Direccion.Select(x=> new { x.CodigoDireccion,x.Calle}).ToString();

            // var personaSexoMasculino = db.Persona.GroupBy(x => x.Sexo).ToString();





            /*
            //Inner join

            var personaDireccion = db.Direccion.Join(db.Persona, dir => dir.IdPersona,
                per => per.Id, (dir, per) => new { dir, per }).FirstOrDefault(x => x.dir.CodigoDireccion == 2);

            //Group Join
            var persona1conSusDirecciones = db.Persona.GroupJoin(db.Direccion, per => per.Id, dir => dir.IdPersona,
                (per, dir) => new { per, dir }).FirstOrDefault(x => x.per.Id == 1);

            // Group Join listado de personas con direcciones
            var personasConSusDirecciones = db.Persona.GroupJoin(db.Direccion, per => per.Id, dir => dir.IdPersona,
                (per, dir) => new { per, dir }).ToList();

            */

            /* Manera 1 de manejar relaciones. Requiere poner virtual en la relacion del modelo. Se usa Lazy loading
            var persona = db.Persona.FirstOrDefault(x => x.Id == 2);
            var direcciones = persona.Direcciones;

            */


            /* Manera 2 de manejar relaciones, sin usar virtual. Aquí se usa Eager Loading
             
            var persona = db.Persona.Include("Direcciones").FirstOrDefault(x => x.Id == 2);
            var direcciones = persona.Direcciones;

            var direccion = db.Direccion.Include("Persona").FirstOrDefault(x => x.CodigoDireccion == 4); //Traigo la direccion.
            var nombre = direccion.Persona.Nombre; //Obtengo nombre de la persona.

            */

            /*
            var persona = new Persona() { Id = 2 };
            db.Persona.Attach(persona);
            db.Direccion.Add(new Direccion() { Calle = "Ejemplo", Persona=persona });
            db.SaveChanges();

            */


            /*
            //Seleccionando todas las columnas de la tabla persona. Listado de Personas
            var listadoPersonasTodasLasColumnas = db.Persona.ToList();

            //Seleccionando una columna. Listado string de nombres
            var listadoNombres = db.Persona.Select(x => x.Nombre).ToList();

            //Varias columnas y proyectandolas a un tipo anonimo. Listado de objetos anonimos con 2 propiedades

            var listadoPersonasVariasColumnasAnonimo = db.Persona.Select(x => new { Nombre = x.Nombre, Edad = x.Edad }).ToList();

            //Seleccionando varias columnas y proyectandolas hacia Persona. Primero se debe hacer un objeto anonimo, despues hacerlo persona

            var listadoPersonasVariasColumnas = db.Persona.Select(x => new { Nombre = x.Nombre, Edad = x.Edad }).ToList()
                .Select(x => new Persona() { Nombre = x.Nombre, Edad = x.Edad }).ToList();
            */

            return View(db.Persona.ToList());
        }

        // GET: Personas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Nacimiento,Edad,Sexo")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Persona.Add(persona);
                db.SaveChanges(); //Deben guardarse los cambios para persistir en SQL Server
                return RedirectToAction("Index");
            }

            return View(persona);
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Personas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Nacimiento,Edad,Sexo")] Persona persona)
        {
             if (ModelState.IsValid)
             {
                 db.Entry(persona).State = EntityState.Modified;
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }
             return View(persona);

            //Varios metodos de edición
            
            /*
            //Metodo 1: Trae el objeto y lo actualiza

            var personaEditar = db.Persona.FirstOrDefault(x => x.Id == 2); //busco una persona con Id 2
            personaEditar.Nombre = "Editado metodo 1";
            personaEditar.Edad = personaEditar.Edad + 1;
            db.SaveChanges(); //Guardar cambios en la db con entity Framework.

            //Metodo 2: Actualización Parcial. 1 o 2 campos. En este ejemplo modificamos el nombre nomás

            var personaEditar2 = new Persona();
            personaEditar2.Id = 3;
            personaEditar2.Nombre = "Editado metodo 2";
            personaEditar2.Edad = 54;
            db.Persona.Attach(personaEditar2); //Le avisamos a entity Framework que vamos a utilizar este objeto
            db.Entry(personaEditar2).Property(x => x.Nombre).IsModified = true; //Le decimos a entity framework que el nombre del objeto se modificó
            db.SaveChanges();


            //Metodo 3: Objeto externo actualizado. Es un objeto que no fue instanciado a partir de una funcion de entity Framework.
            db.Entry(persona).State = EntityState.Modified; //Le avisamos a entity Framework que el objeto viene de afuera y fue modificado
            db.SaveChanges();
            return RedirectToAction("Index");

            */
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Persona persona = db.Persona.Find(id);
            db.Persona.Remove(persona);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
