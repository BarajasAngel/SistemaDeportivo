using Microsoft.AspNetCore.Mvc;

namespace SistemaDeportivo.Controllers
{
    public class InicioController : Controller
    {
        [HttpGet]
        public IActionResult Alumno(){ 
            return  View();
        }
        [HttpGet]
        public IActionResult AlumnoInscito()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ConfigAlumno()
        {
            return View();
        }
    }
}
