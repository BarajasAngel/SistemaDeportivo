using SistemaDeportivo.Models;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDeportivo.Clases
{
    public class ProfesorModel
    {
        General generic = new General();
        public List<Alumnos> AlumnosList()
        {
            using (SistemaDeportivoDBContext db = new SistemaDeportivoDBContext())
            {
                List<Alumnos> lista = new List<Alumnos>();

                var getProfesor = db.Profesores.Where(x =>
                x.Nombre == generic.Usuario).First();

                var getDeporte = db.Deporte.Where(x =>
                x.IdDeporte == getProfesor.IdDeporte).First();

                var getInsctritos = db.DeporteInscrito.Where(x => x.IdDeporte == getDeporte.IdDeporte).ToList();

                for (int i = 0; i < getInsctritos.Count; i++)
                {
                    var getAlumnos = db.Alumnos.Where(x => x.IdAlumno == getInsctritos[i].IdAlumno).First();

                    lista.Add(getAlumnos);
                }
                return lista;
            }
        }
        public ProfesorCLS getProfesor()
        {
            using (SistemaDeportivoDBContext db = new SistemaDeportivoDBContext())
            {
                var getInfo = db.Profesores.Where(x =>
                    x.IdProfesor == generic.IdProfesor).First();
                var getUsuario = db.Usuarios.Where(x =>
                    x.IdUsuario == getInfo.IdUsuario).First();
                var getDeporte = db.Deporte.Where(x =>
                    x.IdDeporte == getInfo.IdDeporte).First();
                var getHorario = db.Horario.Where(x =>
                    x.IdHorario == getDeporte.IdHorario).First();

                ProfesorCLS prof = new ProfesorCLS()
                {
                    IdProfesor = generic.IdProfesor,
                    Usuario = getUsuario.Usuario,
                    Nombre = getInfo.Nombre,
                    NombreDeporte = getDeporte.NombreDeporte,
                    Lunes = getHorario.Lunes,
                    Marte = getHorario.Marte,
                    Miercoles = getHorario.Miercoles,
                    Jueves = getHorario.Jueves,
                    Viernes = getHorario.Viernes
                };

                return prof;
            }

        }
        public int UpdateProfesor(ProfesorCLS profesor)
        {
            using (SistemaDeportivoDBContext db = new SistemaDeportivoDBContext())
            {


                var getDeporte = db.Deporte.Where(x =>
                    x.NombreDeporte == profesor.NombreDeporte).First();
                var setHorario = db.Horario.Where(x =>
                    x.IdHorario == getDeporte.IdHorario).First();
                var getUsuario = db.Usuarios.Where(x =>
                    x.Usuario == profesor.Usuario).First();

                Profesores setProfesor = new Profesores()
                {
                    IdProfesor = profesor.IdProfesor,
                    Nombre = profesor.Nombre,
                    IdDeporte = getDeporte.IdDeporte,
                    IdUsuario = getUsuario.IdUsuario
                };

                setHorario.Lunes = profesor.Lunes;
                setHorario.Marte = profesor.Marte;
                setHorario.Miercoles = profesor.Miercoles;
                setHorario.Jueves = profesor.Jueves;
                setHorario.Viernes = profesor.Viernes;

                try
                {
                    db.Profesores.Update(setProfesor);
                    db.Horario.Update(setHorario);

                    db.SaveChanges();

                    return 1;
                }
                catch (System.Exception)
                {

                    return 2;
                }
            }
        }
        public List<Alumnos> AlumnosNoti()
        {
            using (SistemaDeportivoDBContext db = new SistemaDeportivoDBContext())
            {
                var getNotificacion = db.Solicitud.Where(x =>
                x.IdProfesor == generic.IdProfesor).FirstOrDefault();

                if (getNotificacion != null)
                {
                    var getAlumnos = db.Alumnos.Where(x =>
                        x.IdAlumno == getNotificacion.IdAlumno).ToList();
                    return getAlumnos;
                }
                return new List<Alumnos>();
            }
        }
        public bool DeleteAlumno(int id)
        {
            using (SistemaDeportivoDBContext db = new SistemaDeportivoDBContext())
            {
                var getProfe = db.Profesores.Where(x => x.IdProfesor == generic.IdProfesor).First();
                var setInscrip = db.DeporteInscrito.Where(x => x.IdAlumno == id && x.IdDeporte == getProfe.IdDeporte);
                var setCredencial = db.Credencial.Where(x => x.IdAlumno == id && x.IdProfesor == getProfe.IdDeporte).First();
                var setAlumno = db.Alumnos.Where(x => x.IdAlumno == id).First();
                var setUsuario = db.Usuarios.Where(x => x.IdUsuario == setAlumno.IdUsuario).First();
                var setCupo = db.Deporte.Where(x => x.IdDeporte == getProfe.IdDeporte).First();
                setCupo.Cupo++;
                try
                {
                    db.Credencial.Remove(setCredencial);
                    db.DeporteInscrito.Remove(setInscrip.First());
                    db.Deporte.Update(setCupo);
                    db.SaveChanges();
                    if (setInscrip.ToList().Count() == 0)
                    {
                        setUsuario.IdRol = 3;
                        db.Usuarios.Update(setUsuario);
                        db.SaveChanges();

                    }
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
