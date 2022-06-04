using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaDeportivo.Clases;

namespace SistemaDeportivo.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class AdministradorController : Controller
    {
        AdministradorModel obj = new AdministradorModel();
        
        [HttpGet]        
        public IActionResult Alumno(){
            ViewBag.list = obj.listAlumnos();            
            ViewBag.Mensaje = TempData["mensaje"];
            return View();
        }
        [HttpPost]        
        public IActionResult Alumno(AlumnoCLS alumno)
        {
            if (ModelState.IsValid)
            {

            }
            ViewBag.list = obj.listAlumnos();
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
        [HttpPost]
        public IActionResult Profesor(ProfesorCLS profesor)
        {
            if (ModelState.IsValid)
            {

            }
            ViewBag.list = obj.listProfesores();
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
