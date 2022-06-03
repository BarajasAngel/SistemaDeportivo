using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaDeportivo.Clases;
using SistemaDeportivo.Models;
using System.Collections.Generic;

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
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Alumno")]
        public IActionResult Alumno(string Deporte)
        {             
            return RedirectToAction("AlumnoInscito");
        }
        [HttpGet]
        [Authorize(Roles = "Alumno")]
        public IActionResult AlumnoInscito()
        {
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "Alumno")]
        public IActionResult ConfigAlumno()
        {            
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Alumno")]
        public IActionResult ConfigAlumno(AlumnoCLS alumno) {
            if (ModelState.IsValid)
            {
                return View();
            }
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "Profesor")]
        public IActionResult Profesor() {
            ViewBag.Lista = obj2.AlumnosList();
            return View();
        }

    }
}
