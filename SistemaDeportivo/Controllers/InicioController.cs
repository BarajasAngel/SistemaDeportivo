using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        AlumnoModel obj = new AlumnoModel();
        ProfesorModel obj2 = new ProfesorModel();

        [HttpGet]
        [Authorize(Roles= "Alumno")]
        public IActionResult Alumno() {
            ViewBag.List = obj.Read();
            ViewBag.Bool = false;
            ViewBag.Deportes = obj.Deportes();
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Alumno")]
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
            return View();
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
                ViewBag.Bool = obj.Update(alumno);
            }
            return View(obj.ReadInfo());
        }
        [HttpGet]
        [Authorize(Roles = "AlumnoInscrito")]
        public FileResult Credencial() {
            FileStream documento = new CredencialCLS().credencial();
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
