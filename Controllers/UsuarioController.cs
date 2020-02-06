using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LabTito.Models;

namespace LabTito.Controllers
{
    public class UsuarioController : Controller
    {
        public static List<CLiente> GuardandoUsuario = new List<CLiente>();
        public static bool Ordenamiento = false;
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var NuevoCliente = new CLiente
                {
                    nombre= collection["nombre"],
                    Descripcion= collection["Descripcion"],
                    Apellido= collection["Apellido"],
                    Telefono= collection["Telefono"]
                
                };

                GuardandoUsuario.Add(NuevoCliente);
                
                return RedirectToAction("Index");
            }
                catch
            {
                return View();
            }
        }
        
        // GET: Usuario/Create
        public ActionResult Lista()
        {
            if (Ordenamiento)
            {
            //ordenar por nombre
            GuardandoUsuario.Sort((x, y) => x.nombre.CompareTo(y.nombre));

            }
            else
            {
            //ordenar por apellido
            GuardandoUsuario.Sort((x, y) => x.Apellido.CompareTo(y.Apellido));

            }
            return View(GuardandoUsuario);
        }
        
        // GET: Usuario/Edit/5
        public ActionResult OrdenamientoMetodo()
        {
            return View();
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult OrdenamientoMetodo(FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var entrada = new Entrada
                {
                    Opcion = Convert.ToBoolean(collection["Opcion"])

                };
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
    }
}
