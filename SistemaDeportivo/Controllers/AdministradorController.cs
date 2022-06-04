using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaDeportivo.Clases;
using SistemaDeportivo.Models;

namespace SistemaDeportivo.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class AdministradorController : Controller
    {
        AdministradorModel obj = new AdministradorModel();

        [HttpGet]
        public IActionResult Alumno() {
            ViewBag.list = obj.listAlumnos();
            ViewBag.Mensaje = TempData["mensaje"];
            return View();
        }
        [HttpGet]
        public IActionResult ModificarAlumno(int id)
        {
            return View(obj.getAlumno(id));
        }
        [HttpPost]
        public IActionResult ModificarAlumno(Alumnos alumno)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Bool = obj.UpdateAlumno(alumno);
            }
            return View();
        }
        [HttpPost]
        public RedirectToActionResult EliminarAlumno(int id) {
            var booleanito = obj.DeleteAlumno(id);
            if (booleanito)
            {
                TempData["mensaje"] = "1";
                ViewBag.Bool = "El Alumno fue eliminado con exito";
            }
            else
            {
                TempData["mensaje"] = "2";
                ViewBag.Bool = "No pudimos eliminar a este alumno";
            }
            return RedirectToAction("Alumno");
        }
        [HttpGet]
        public IActionResult Profesor() {
            ViewBag.list = obj.listProfesores();
            ViewBag.Mensaje = TempData["mensaje"];
            return View();
        }
        [HttpGet]
        public IActionResult ModificarProfesor(int id)
        {
            ViewBag.Bool = 0;
            return View(obj.getProfesor(id));
        }
        [HttpPost]
        public IActionResult ModificarProfesor(ProfesorCLS profesor)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Bool = obj.UpdateProfesor(profesor);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AgregarProfesor(){
            ViewBag.Bool = 0;
            return View();
        }
        [HttpPost]
        public IActionResult AgregarProfesor(ProfesorCLS profesor)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Bool = obj.CreateProfesor(profesor);
            }
            return View();
        }
        [HttpPost]
        public RedirectToActionResult EliminarProfesor(int id)
        {
            if (obj.DeleteProfesor(id))
            {
                TempData["mensaje"] = "1";
            }
            else
            {
                TempData["mensaje"] = "2";
            }
            return RedirectToAction("Profesor");
        }
    }
}
