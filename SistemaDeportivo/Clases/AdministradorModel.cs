using SistemaDeportivo.Models;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDeportivo.Clases
{
    public class AdministradorModel
    {
        public List<AlumnoCLS> listAlumnos() {
            using (SistemaDeportivoDBContext db = new SistemaDeportivoDBContext())
            {
                var getAlumno = db.Alumnos.ToList();
                List<AlumnoCLS> list = new List<AlumnoCLS>();
                for (int i = 0; i < getAlumno.Count; i++)
                {
                    var getUsuario = db.Usuarios.Where(x => x.IdUsuario == getAlumno[i].IdUsuario).First();
                    list.Add(new AlumnoCLS { 
                        IdAlumno = getUsuario.IdUsuario,
                        Usuario = getUsuario.Usuario,
                        Nombre = getAlumno[i].Nombre,
                        ApellidoPat = getAlumno[i].ApellidoPat,
                        ApellidoMat = getAlumno[i].ApellidoMat,
                        Edad = getAlumno[i].Edad,
                        Sexo = getAlumno[i].Sexo,
                        Correo = getAlumno[i].Correo,
                        Celular = getAlumno[i].Celular
                    });
                }
                return list;
            }                        
        } 
    }
}
