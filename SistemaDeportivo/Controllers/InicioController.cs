using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SistemaDeportivo.Clases;
using SistemaDeportivo.Models;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SistemaDeportivo.Controllers
{
    public class InicioController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment hostEnvironment;

        public InicioController(ILogger<HomeController> logger, IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            this.hostEnvironment = hostEnvironment;
        }

        AlumnoModel obj = new AlumnoModel();
        ProfesorModel obj2 = new ProfesorModel();        

        [HttpGet]
        [Authorize(Roles= "Alumno,AlumnoInscrito")]
        public IActionResult Alumno() {
            ViewBag.List = obj.Read();
            ViewBag.Bool = false;
            ViewBag.Deportes = obj.Deportes();
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Alumno,AlumnoInscrito")]
        public async Task<IActionResult> Alumno(string Deporte)
        {
            if (obj.Update(Deporte))
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                var claimsAdmin = new List<Claim>();                        
                claimsAdmin.Add(new Claim(ClaimTypes.Role, "AlumnoInscrito"));
                var claimsIdentityAdmin = new ClaimsIdentity(claimsAdmin, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentityAdmin));

                return RedirectToAction("AlumnoInscrito");
            }
            ViewBag.Bool = true;            
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "AlumnoInscrito")]
        public IActionResult AlumnoInscrito()
        {
            ViewBag.Lista = obj.DeportesInscritos();            
            return View();
        }
        [HttpPost]
        public RedirectToActionResult Solicitud(int id) {
            TempData["Mensaje"] = obj.Solicitar(id);
            return RedirectToAction("AlumnoInscrito");
        }
        [HttpGet]
        [Authorize(Roles = "Alumno, AlumnoInscrito")]        
        public IActionResult ConfigAlumno()
        {
            ViewBag.Bool = 0;
            return View(obj.ReadInfo());
        }
        [HttpPost]
        [Authorize(Roles = "Alumno,AlumnoInscrito")]
        public IActionResult ConfigAlumno(AlumnoCLS alumno) {
            if (ModelState.IsValid)
            {
                //ViewBag.Bool = obj.Update(alumno);
            }
            return View(obj.ReadInfo());
        }
        [HttpGet]
        [Authorize(Roles = "AlumnoInscrito")]
        public FileResult Credencial() {

            string wwwRootPath = hostEnvironment.WebRootPath;
            FileStream documento = new CredencialCLS(wwwRootPath).credencial();
            return File(documento, "application/pdf");
        }
        [HttpGet]
        [Authorize(Roles = "Profesor")]
        public IActionResult Profesor() {
            ViewBag.Lista = obj2.AlumnosList();
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "Profesor")]
        public IActionResult Notificaciones() {
            ViewBag.Lista = obj2.AlumnosNoti();
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Profesor")]
        public RedirectToActionResult EliminarAlumno(int id)
        {
            var booleanito = obj2.DeleteAlumno(id);
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
            return RedirectToAction("Profesor");
        }
        [HttpGet]
        [Authorize(Roles = "Profesor")]
        public IActionResult ConfigProfesor() {
            ViewBag.Bool = 0;
            return View(obj2.getProfesor());
        }
        [HttpPost]
        [Authorize(Roles = "Profesor")]
        public IActionResult ConfigProfesor(ProfesorCLS profesor)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Bool = obj2.UpdateProfesor(profesor);
            }
            return View();
        }
    }
}
