
using SistemaDeportivo.Models;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDeportivo.Clases
{
    public class AlumnoModel
    {
        General generic = new General();
        public string Create(AlumnoCLS alumno)
        {
            using (SistemaDeportivoDBContext db = new SistemaDeportivoDBContext())
            {
                if (Validation(alumno.Usuario, alumno.Contraseña) != "")
                {
                    return "Este usuario ya existe";
                }
                Usuarios setUser = new Usuarios()
                {
                    Usuario = alumno.Usuario,
                    Contraseña = alumno.Contraseña,
                    IdRol = 3
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
                    IdDeporte = null,
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
        public string Validation(string usuario, string contraseña)
        {
            using (SistemaDeportivoDBContext db = new SistemaDeportivoDBContext())
            {
                var getUsuario = db.Usuarios.Where(x =>
                x.Usuario == usuario && x.Contraseña == contraseña).FirstOrDefault();

                if (getUsuario != null)
                {
                    var getRol = db.Rol.Where(x =>
                    x.IdRol == getUsuario.IdRol).FirstOrDefault().Nombre;
                    generic.Usuario = getName(getUsuario.IdUsuario, getRol);
                    return getRol;
                }

                return "";
            }
        }
        private string getName(int idUsuario, string rol)
        {
            using (SistemaDeportivoDBContext db = new SistemaDeportivoDBContext())
            {
                var getAdmin = db.Administrator.Where(x => x.IdUsuario == idUsuario).FirstOrDefault();
                if (getAdmin != null)
                {
                    generic.Rol = rol;
                    return $"{getAdmin.Nombre}";
                }
                var getProfesor = db.Profesores.Where(x => x.IdUsuario == idUsuario).FirstOrDefault();
                if (getProfesor != null)
                {
                    generic.Rol = rol;
                    return $"{getProfesor.Nombre}";
                }
                var getAlumno = db.Alumnos.Where(x => x.IdUsuario == idUsuario).FirstOrDefault();
                if (getAlumno != null)
                {
                    var getDeporte = db.Deporte.Where(x =>
                        x.IdDeporte == getAlumno.IdDeporte).FirstOrDefault();
                    if (getDeporte != null)
                    {
                        generic.Deporte = getDeporte.NombreDeporte;
                    }
                    generic.Rol = rol;
                    generic.IdAlumno = getAlumno.IdAlumno;
                    return $"{getAlumno.Nombre} {getAlumno.ApellidoPat} {getAlumno.ApellidoMat}";
                }
                return "";
            }
        }
        public List<ProfesorCLS> Read()
        {
            using (SistemaDeportivoDBContext db = new SistemaDeportivoDBContext())
            {
                var listProf = db.Profesores.ToList();

                List<ProfesorCLS> getProfes = new List<ProfesorCLS>();

                for (int i = 0; i < listProf.Count; i++)
                {
                    var listDeporte = db.Deporte.Where(x => x.IdDeporte == listProf[i].IdDeporte).First();
                    var lisHorario = db.Horario.Where(x => x.IdHorario == listDeporte.IdHorario).First();

                    getProfes.Add(new ProfesorCLS
                    {
                        IdProfesor = listProf[i].IdProfesor,
                        Nombre = listProf[i].Nombre,
                        NombreDeporte = listDeporte.NombreDeporte,
                        Lunes = lisHorario.Lunes,
                        Marte = lisHorario.Marte,
                        Miercoles = lisHorario.Miercoles,
                        Jueves = lisHorario.Jueves,
                        Viernes = lisHorario.Viernes,
                    });
                }
                return getProfes;
            }
        }
        public AlumnoCLS ReadInfo()
        {
            using (SistemaDeportivoDBContext db = new SistemaDeportivoDBContext())
            {
                var getInfo = db.Alumnos.Where(x =>
                x.IdAlumno == generic.IdAlumno).First();
                var getUser = db.Usuarios.Where(x =>
                x.IdUsuario == getInfo.IdUsuario).First();

                AlumnoCLS getAlumno = new AlumnoCLS()
                {
                    Usuario = getUser.Usuario,
                    Nombre = getInfo.Nombre,
                    ApellidoPat = getInfo.ApellidoPat,
                    ApellidoMat = getInfo.ApellidoMat,
                    Edad = getInfo.Edad,
                    Sexo = getInfo.Sexo,
                    Correo = getInfo.Correo,
                    Celular = getInfo.Celular
                };

                return getAlumno;
            }
        }
        public bool Update(string deporte)
        {
            using (SistemaDeportivoDBContext db = new SistemaDeportivoDBContext())
            {
                var getAlumno = db.Alumnos.Where(x => x.IdAlumno == generic.IdAlumno).First();
                getAlumno.IdDeporte = int.Parse(deporte);
                var getProfe = db.Profesores.Where(x => x.IdDeporte == getAlumno.IdDeporte).First();
                var getUsuario = db.Usuarios.Where(x => x.IdUsuario == getAlumno.IdUsuario).First();
                getUsuario.IdRol = 4;
                try
                {
                    db.Update(getAlumno);
                    db.Update(getUsuario);

                    db.Credencial.Add(new Credencial {
                        IdProfesor = getProfe.IdProfesor,
                        IdAlumno = getAlumno.IdAlumno
                    });

                    db.SaveChanges();

                    return true;
                }
                catch (System.Exception)
                {

                    return false;
                }
            }
        }
        public bool Update(Alumnos alumnos)
        {
            using (SistemaDeportivoDBContext db = new SistemaDeportivoDBContext())
            {
                try
                {
                    db.Update(alumnos);
                    db.SaveChanges();
                    return true;
                }
                catch (System.Exception)
                {

                    return false;
                }
            }
        }

    }
}
