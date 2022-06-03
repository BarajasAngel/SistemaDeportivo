using SistemaDeportivo.Models;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDeportivo.Clases
{
    public class ProfesorModel
    {
        General generic = new General();
        public List<Alumnos> AlumnosList() {
            using (SistemaDeportivoDBContext db = new SistemaDeportivoDBContext()) {

                var getProfesor = db.Profesores.Where(x => 
                x.Nombre == generic.Usuario).First();

                var getDeporte = db.Deporte.Where(x => 
                x.IdDeporte == getProfesor.IdDeporte).First();

                var getAlumnos = db.Alumnos.Where(x =>
                x.IdDeporte == getDeporte.IdDeporte).ToList();               

                return getAlumnos;
            }        
        }
    }
}
