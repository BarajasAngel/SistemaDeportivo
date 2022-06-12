
using Microsoft.EntityFrameworkCore;
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

                var getIdUsuario = db.Usuarios.ToList().Last();

                Alumnos setAlumno = new Alumnos()
                {
                    Nombre = alumno.Nombre,
                    ApellidoPat = alumno.ApellidoPat,
                    ApellidoMat = alumno.ApellidoMat,
                    Edad = alumno.Edad,
                    Sexo = alumno.Sexo,
                    Correo = alumno.Correo,
                    Celular = alumno.Celular,                    
                    IdUsuario = getIdUsuario.IdUsuario
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
                    generic.IdProfesor = getProfesor.IdProfesor;
                    generic.Rol = rol;
                    return $"{getProfesor.Nombre}";
                }
                var getAlumno = db.Alumnos.Where(x => x.IdUsuario == idUsuario).FirstOrDefault();
                if (getAlumno != null)
                {
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
                    var getInscrip = db.DeporteInscrito.Where(x => 
                        x.IdAlumno == generic.IdAlumno && x.IdDeporte == listDeporte.IdDeporte).FirstOrDefault();

                    if (listDeporte.Cupo > 0 && getInscrip == null)
                    {
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
                            Cupo = listDeporte.Cupo
                        });
                    }
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
                    IdAlumno = getInfo.IdAlumno,                    
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
                var getDeporte = db.Deporte.Where(x => x.IdDeporte == int.Parse(deporte)).First();
                DeporteInscrito setInscrip = new DeporteInscrito() { 
                    IdAlumno = getAlumno.IdAlumno,
                    IdDeporte = getDeporte.IdDeporte
                };                

                db.DeporteInscrito.Add(setInscrip);
                db.SaveChanges();                
                     
                var getProfe = db.Profesores.Where(x => x.IdDeporte == setInscrip.IdDeporte).First();
                var getUsuario = db.Usuarios.Where(x => x.IdUsuario == getAlumno.IdUsuario).First();
                getUsuario.IdRol = 4;

                generic.Rol = "AlumnoInscrito";

                getDeporte.Cupo--;
                var getCredencial = db.Credencial.Where(x => x.IdProfesor == getProfe.IdProfesor).FirstOrDefault();

                if (getCredencial != null)
                {
                    return false;
                }

                try
                {
                    db.Deporte.Update(getDeporte);
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

        #region Actualizar informacion del alumno (No funcional)
        //public int Update(AlumnoCLS alumnos)
        //{
        //    using (SistemaDeportivoDBContext db = new SistemaDeportivoDBContext())
        //    {                
        //        var getAlumno = db.Alumnos.Where(x => x.IdAlumno == alumnos.IdAlumno).First();
        //        var getUsuario = db.Usuarios.Where(x => x.IdUsuario == getAlumno.IdUsuario).First();

        //        Alumnos setAlumno = new Alumnos();

        //        setAlumno.IdAlumno = getAlumno.IdAlumno;
        //        setAlumno.IdUsuario = getUsuario.IdUsuario;
        //        setAlumno.Nombre = alumnos.Nombre;
        //        setAlumno.ApellidoPat = alumnos.ApellidoPat;
        //        setAlumno.ApellidoMat = alumnos.ApellidoMat;
        //        setAlumno.Edad = alumnos.Edad;
        //        setAlumno.Sexo = alumnos.Sexo;
        //        setAlumno.Correo = alumnos.Correo;
        //        setAlumno.Celular = alumnos.Celular;
        //        setAlumno.IdDeporteInscrito = getAlumno.IdDeporteInscrito;               



        //        //Alumnos setAlumno = new Alumnos()
        //        //{
        //        //    IdAlumno = getAlumno.IdAlumno,
        //        //    IdUsuario = getUsuario.IdUsuario,
        //        //    Nombre = alumnos.Nombre,
        //        //    ApellidoPat = alumnos.ApellidoPat,
        //        //    ApellidoMat = alumnos.ApellidoMat,
        //        //    Edad = alumnos.Edad,
        //        //    Sexo = alumnos.Sexo,
        //        //    Correo = alumnos.Correo,
        //        //    Celular = alumnos.Celular,
        //        //    IdDeporte = getAlumno.IdDeporte
        //        //};                                

        //        Usuarios setUsuarios = new Usuarios();
        //        setUsuarios.Usuario = getUsuario.Usuario;
        //        setUsuarios.Contraseña = alumnos.Contraseña;
        //        setUsuarios.IdUsuario = getUsuario.IdUsuario;
        //        setUsuarios.IdRol = getUsuario.IdRol;


        //        //Usuarios setUsuario = new Usuarios()
        //        //{
        //        //    Usuario = getUsuario.Usuario,
        //        //    Contraseña = alumnos.Contraseña,
        //        //    IdUsuario = getUsuario.IdUsuario,
        //        //    IdRol = getUsuario.IdRol,                    
        //        //};

        //        try
        //        {                                        
        //            db.Usuarios.Update(setUsuarios);
        //            db.Alumnos.Update(setAlumno);                    
        //            db.SaveChanges();
        //            return 1;
        //        }
        //        catch (System.Exception EX)
        //        {
        //            string variable = EX.Message;
        //            return 2;
        //        }
        //    }
        //}
        #endregion

        public List<string[]> Deportes() {
            using (SistemaDeportivoDBContext db = new SistemaDeportivoDBContext())
            {
                List<string[]> list = new List<string[]>();
                var getProfes = db.Profesores.ToList();                
                

                for (int i = 0; i < getProfes.Count; i++)
                {
                    var getDeporte = db.Deporte.Where(x =>
                        x.IdDeporte == getProfes[i].IdDeporte).First();
                    var getInscrip = db.DeporteInscrito.Where(x =>
                        x.IdAlumno == generic.IdAlumno && x.IdDeporte == getDeporte.IdDeporte).FirstOrDefault();

                    if (getDeporte.Cupo>0 && getInscrip == null)
                    {                        
                        list.Add(new string[] { getDeporte.IdDeporte.ToString(), getDeporte.NombreDeporte });                                                
                    }
                }
                return list;
            }               
        }
        public List<DeporteCLS> DeportesInscritos() {
            using (SistemaDeportivoDBContext db = new SistemaDeportivoDBContext())
            {
                List<DeporteCLS> lista = new List<DeporteCLS>();
                var getCredencial = db.Credencial.Where(x => x.IdAlumno == generic.IdAlumno).ToList();
                

                for (int i = 0; i < getCredencial.Count; i++)
                {                    
                    var getProfesor = db.Profesores.Where(x => x.IdProfesor == getCredencial[i].IdProfesor).First();
                    var getDeporte = db.Deporte.Where(x => x.IdDeporte == getProfesor.IdDeporte).First();

                    if (true)
                    {
                        lista.Add(new DeporteCLS { IdDeporte = getProfesor.IdProfesor, NombreProfesor = getProfesor.Nombre, NombreDeporte = getDeporte.NombreDeporte });  
                    }
                }
                return lista;
            }                
        }
        public string Solicitar(int id) {
            using (SistemaDeportivoDBContext db =  new SistemaDeportivoDBContext())
            {
                var getAlumno = db.Alumnos.Where(x => x.IdAlumno == generic.IdAlumno).First();                
                Solicitud setSolicitud = new Solicitud() {
                    IdProfesor = id,
                    IdAlumno = getAlumno.IdAlumno                    
                };

                try
                {
                    db.Solicitud.Add(setSolicitud);
                    db.SaveChanges();

                    return "Solicitud mandada correctamente";
                }
                catch (System.Exception)
                {
                    return "No pudimos procesar tu solicitud, contacta con tu profesor";
                }
            }        
        } 
    }
}
