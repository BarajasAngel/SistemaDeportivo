using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaDeportivo.Clases;
using SistemaDeportivo.Models;
using System.Collections.Generic;
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
            return View(obj.ReadInfo());
        }
        [HttpPost]
        [Authorize(Roles = "Alumno,AlumnoInscrito")]
        public IActionResult ConfigAlumno(AlumnoCLS alumno) {
            if (ModelState.IsValid)
            {
                return View(obj.ReadInfo());
            }
            return View(obj.ReadInfo());
        }
        [HttpGet]
        [Authorize(Roles = "Profesor")]
        public IActionResult Profesor() {
            ViewBag.Lista = obj2.AlumnosList();
            return View();
        }        

    }
}
