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
                        IdAlumno = getAlumno[i].IdAlumno,
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
        public Alumnos getAlumno(int id)
        {
            using (SistemaDeportivoDBContext db = new SistemaDeportivoDBContext())
            {
                var getInfo = db.Alumnos.Where(x =>
                    x.IdAlumno == id).FirstOrDefault();
                if (getInfo != null)
                {
                    return getInfo; 
                }
                return null;
            }
        }
        public int UpdateAlumno(Alumnos alumno) {
            using (SistemaDeportivoDBContext db = new SistemaDeportivoDBContext())
            {
                try
                {
                    db.Alumnos.Update(alumno);

                    db.SaveChanges();

                    return 1;
                }
                catch (System.Exception)
                {
                    return 2;
                }
            }        
        }
        public bool DeleteAlumno(int id)
        {
            using (SistemaDeportivoDBContext db = new SistemaDeportivoDBContext())
            {
                var getCredencial = db.Credencial.Where(x => 
                    x.IdAlumno == id).FirstOrDefault();

                var getAlumno = db.Alumnos.Where(x => 
                    x.IdAlumno == id).First();

                var getUsuario = db.Usuarios.Where(x => 
                    x.IdUsuario == getAlumno.IdUsuario).First();

                try
                {
                    if (getCredencial != null)
                    {
                        db.Credencial.Remove(getCredencial); 
                    }
                    db.Alumnos.Remove(getAlumno);
                    db.Usuarios.Remove(getUsuario);

                    db.SaveChanges();

                    return true;
                }
                catch (System.Exception)
                {
                    return false;
                }
            }
        }
        public List<ProfesorCLS> listProfesores() {

            using (SistemaDeportivoDBContext db = new SistemaDeportivoDBContext())
            {
                var listProf = db.Profesores.ToList();

                List<ProfesorCLS> getProfes = new List<ProfesorCLS>();

                for (int i = 0; i < listProf.Count; i++)
                {
                    var listDeporte = db.Deporte.Where(x => x.IdDeporte == listProf[i].IdDeporte).First();
                    var lisHorario = db.Horario.Where(x => x.IdHorario == listDeporte.IdHorario).First();
                    var getUsuario = db.Usuarios.Where(x => x.IdUsuario == listProf[i].IdUsuario).First();

                    getProfes.Add(new ProfesorCLS
                    {
                        IdProfesor = listProf[i].IdProfesor,
                        Usuario = getUsuario.Usuario,
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
        public bool DeleteProfesor(int id) {
            using (SistemaDeportivoDBContext db = new SistemaDeportivoDBContext())
            {
                var getProfe = db.Profesores.Where(x =>
                    x.IdProfesor == id).First();
                var getCredencial = db.Credencial.Where(x =>
                    x.IdProfesor == id).ToList();
                var getUsuario = db.Usuarios.Where(x =>
                    x.IdUsuario == getProfe.IdUsuario).First();                

                if (getCredencial.Count == 0)
                {
                    try
                    {
                        db.Remove(getProfe);
                        db.Remove(getUsuario);

                        db.SaveChanges();

                        return true;
                    }
                    catch (System.Exception)
                    {

                        return false;
                    }
                }

                for (int i = 0; i < getCredencial.Count; i++)
                {
                    var getAlumno = db.Alumnos.Where(x =>
                        x.IdAlumno == getCredencial[i].IdAlumno).First();
                    getAlumno.IdDeporte = null;
                    var getUsuarioAlumno = db.Usuarios.Where(x =>
                    x.IdUsuario == getAlumno.IdUsuario).First();
                    getUsuarioAlumno.IdRol = 3;

                    db.Usuarios.Update(getUsuarioAlumno);
                    db.Alumnos.Update(getAlumno);
                    db.Credencial.Remove(getCredencial[i]);

                    db.SaveChanges();                    
                }

                try
                {
                    db.Profesores.Remove(getProfe);
                    db.Usuarios.Remove(getUsuario);

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
