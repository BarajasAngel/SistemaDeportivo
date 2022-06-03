﻿using Microsoft.AspNetCore.Mvc;
using SistemaDeportivo.Clases;
using SistemaDeportivo.Models;
using System.Collections.Generic;

namespace SistemaDeportivo.Controllers
{
    public class InicioController : Controller
    {
        AlumnoModel obj = new AlumnoModel();

        [HttpGet]
        public IActionResult Alumno(){
            ViewBag.List = obj.Read();
            return View();
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
