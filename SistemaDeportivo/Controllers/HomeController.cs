using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SistemaDeportivo.Clases;
using SistemaDeportivo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeportivo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        AlumnoModel obj = new AlumnoModel();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Login() {
            ViewBag.Bool = false;
            return View();
        }
        [HttpPost]
        public IActionResult Login(Usuarios user)
        {
            if (ModelState.IsValid) {
                if (obj.Validation(user.Usuario,user.Contraseña))
                {                   
                    return Content("Hola mundo");
                }
                ViewBag.Bool = true;
                return View();
            }
            ViewBag.Bool = false;
            return View();
        }
        [HttpGet]
        public IActionResult Registro() {
            ViewBag.Bool = false;
            return View();
        }
        [HttpPost]
        public IActionResult Registro(AlumnoCLS alumno)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Bool = true;
                ViewBag.Mensaje = obj.Create(alumno);
                return View();
            }
            ViewBag.Bool = false;
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
