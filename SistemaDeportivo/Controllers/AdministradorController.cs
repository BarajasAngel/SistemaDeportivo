using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaDeportivo.Clases;

namespace SistemaDeportivo.Controllers
{
    public class AdministradorController : Controller
    {
        AdministradorModel obj = new AdministradorModel();
        [Authorize(Roles = "Administrador")]
        public IActionResult Alumno(){
            ViewBag.list = obj.listAlumnos();
            return View();
        }
        [Authorize(Roles = "Administrador")]
        public IActionResult Profesor() {
            return View();
        }
    }
}
