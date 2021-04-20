using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProyectoWEB3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoWEB3.Controllers
{
    public class HomeController : Controller
    {
      
       // [Authorize(Roles ="ApruebaPrestamos,Visualiza.index")] //AQUI DETERMINAMOS QUIEN USA LAS ACCIONES DEL CONTROLADOR Y QUE ACCION
        public ActionResult Index()
        {

            //Obtener datos del lugar de nacimiento usuario

            if (User.Identity.IsAuthenticated)
            {
                using (ApplicationDbContext db = new ApplicationDbContext()) //Siempre para manejar usuarios se hace este codigo
                {
                    var idUsuarioActual = User.Identity.GetUserId();

                    var userManager = new UserManager<ApplicationUser> //Creamos manejador de usuarios
                        (new UserStore<ApplicationUser>(db));

                    var usuario = userManager.FindById(idUsuarioActual);
                    var lugarNacimiento = usuario.LugarNacimiento;
                   

                }
            }


            /*
            //ROLES

            if (User.Identity.IsAuthenticated)
            {
                using (ApplicationDbContext db = new ApplicationDbContext()) //Siempre para manejar usuarios se hace este codigo
                {
                    var idUsuarioActual = User.Identity.GetUserId();
                    var roleManager = new RoleManager<IdentityRole>
                        (new RoleStore<IdentityRole>(db));


                    //Crear Rol
                    var resultado = roleManager.Create(new IdentityRole("ApruebaPrestamos")); //Se lep pasa la clase IdentityRole y despues creamos rol

                    var userManager = new UserManager<ApplicationUser> //Creamos manejador de usuarios
                        (new UserStore<ApplicationUser>(db));

                    //Agregar usuario a rol. Ya se guardan los cambios gracias al userManager
                    resultado = userManager.AddToRole(idUsuarioActual, "ApruebaPrestamos"); //Asignamos al usuario un rol


                    //Usuario esta en rol? Podemos ver si tiene el rol para que acceda a o no a un determinado sitio
                    var usuarioEstaenRol = userManager.IsInRole(idUsuarioActual, "ApruebaPrestamos");
                    var usuarioEstaEnRol2 = userManager.IsInRole(idUsuarioActual, "TDC.Reportes.Distribuciones");

                    //Roles de usuarios
                    var roles = userManager.GetRoles(idUsuarioActual);

                    //Removerle a un usuario un Rol
                    resultado = userManager.RemoveFromRole(idUsuarioActual, "ApruebaPrestamos");

                    //Borrar Rol
                    var rolVendedor = roleManager.FindByName("ApruebaPrestamos"); //Si o si primero se debe buscar el rol
                    roleManager.Delete(rolVendedor);

                }
            }
            */


            return View();
        }


        /*
        public ActionResult Index()
        {

            var estaAutenticado = User.Identity.IsAuthenticated;
            if (estaAutenticado)
            {
                var NombreUsuario = User.Identity.Name; //La propiedad de identity nos permite obtener toda la info del usuario
                var id = User.Identity.GetUserId();

                //Toda la informacion del usuario a través de EntityFramework
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var usuario = db.Users.Where(x => x.Id == id).FirstOrDefault();
                    var emailConfirmado = usuario.EmailConfirmed;

                    var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db)); //Pasamos la db

                    var user = new ApplicationUser();
                    user.UserName = "MatiMulassi";
                    user.Email = "Mulassimatias@gmail.com";

                    //Usar siempre el userManager para manejar cosas de usuarios.
                    //var usuario2 = userManager.FindById(id); //Nos evita tener que trabajar con las tablas

                    //Crear Usuario
                    var resultado = userManager.Create(user, "Zombritaj1!"); //No hace falta guarda cambios en la Db. Solito se encarga de hacerlo el UserManager
                }

            }
                return View();
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