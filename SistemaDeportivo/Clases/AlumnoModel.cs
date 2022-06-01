using SistemaDeportivo.Models;
using System.Linq;

namespace SistemaDeportivo.Clases
{
    public class AlumnoModel
    {
        public string Create(AlumnoCLS alumno) {
            using (SistemaDeportivoDBContext db = new SistemaDeportivoDBContext())
            {
                Usuarios setUser = new Usuarios(){
                    Usuario = alumno.Usuario,
                    Contraseña = alumno.Contraseña,
                    IdRol = 1                    
                };

                db.Add(setUser);
                db.SaveChanges();

                var getIdUsuario = db.Usuarios.Where(x => x.Usuario == alumno.Usuario).First().IdUsuario;

                Alumnos setAlumno = new Alumnos()
                {
                    Nombre = alumno.Nombre,
                    ApellidoPat = alumno.ApellidoPat,
                    ApellidoMat = alumno.ApellidoMat,
                    Edad = alumno.Edad,
                    Sexo = alumno.Sexo,
                    Correo = alumno.Correo,
                    Celular = alumno.Celular,
                    IdDeporte = int.Parse(alumno.IdDeporte),
                    IdUsuario = getIdUsuario                    
                };

                try
                {
                    db.Add(setAlumno);
                    db.SaveChanges();

                    return "El usuario fue registrado con éxito";
                }
                catch (System.Exception)
                {
                    return "Hubo un error al realizar el registro, si estas viendo esto contacta con el programador";
                    
                }               
            }            
        }
        //public bool Validation(Usuarios user) {
        //    using (SistemaDeportivoDBContext db = new SistemaDeportivoDBContext())
        //    {

        //    }        
        //}
        public string Update() {
            return "";
        }
        public string Delete() {
            return "";
        }
        public string Read() {
            return "";
        }
    }
}
