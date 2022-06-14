using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SistemaDeportivo.Clases;
using SistemaDeportivo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
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
        public async Task<IActionResult> LoginAsync(Usuarios user)
        {            
            if (ModelState.IsValid) {
                string rol = obj.Validation(user.Usuario, user.Contraseña);
                ViewData["Rol"] = rol;
                switch (rol)
                {
                    case "Administrador":
                        await InsertarRol(user, rol);
                        return RedirectToAction("Alumno", "Administrador");
                    case "Profesor":
                        await InsertarRol(user, rol);
                        return RedirectToAction("Profesor","Inicio");
                    case "Alumno":
                        await InsertarRol(user, rol);
                        return RedirectToAction("Alumno", "Inicio");
                    case "AlumnoInscrito":
                        await InsertarRol(user, rol);
                        return RedirectToAction("AlumnoInscrito", "Inicio");
                    default:
                        ViewBag.Bool = true;
                        return View();                        
                }                
            }
            ViewBag.Bool = false;
            return View();
        }
        private async Task<string> InsertarRol(Usuarios user, string rol) {
            var claimsAdmin = new List<Claim>
                        {
                            new Claim("Usuario", user.Usuario),
                            new Claim("Contraseña", user.Contraseña),
                        };
            claimsAdmin.Add(new Claim(ClaimTypes.Role, rol));
            var claimsIdentityAdmin = new ClaimsIdentity(claimsAdmin, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentityAdmin));
            return "";
        }
        [HttpGet]
        public IActionResult Registro() {
            AlumnoCLS alumno = new AlumnoCLS();
            ViewBag.Bool = false;
            return View(alumno);
        }
        [HttpPost]
        public IActionResult Registro(AlumnoCLS alumno)
        {            
            if (ModelState.IsValid)
            {
                ViewBag.Bool = true;
                ViewBag.Mensaje = obj.Create(alumno);
                if (ViewBag.Mensaje != "1")
                {
                    if (ViewBag.Mensaje != "2")
                    {
                        return RedirectToAction("Login");
                    }
                    ViewBag.Mensaje = "El usuario ya existe";
                    return View();
                }
                ViewBag.Mensaje = "Hubo un error al realizar el registro, si estas viendo esto contacta con el programador";
                return View();
            }
            ViewBag.Bool = false;
            return View();
        }
        public async Task<RedirectToActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login","Home");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
