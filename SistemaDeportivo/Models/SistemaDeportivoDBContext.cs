using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SistemaDeportivo.Models
{
    public partial class SistemaDeportivoDBContext : DbContext
    {
        public SistemaDeportivoDBContext()
        {
        }

        public SistemaDeportivoDBContext(DbContextOptions<SistemaDeportivoDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrator { get; set; }
        public virtual DbSet<Alumnos> Alumnos { get; set; }
        public virtual DbSet<Credencial> Credencial { get; set; }
        public virtual DbSet<Deporte> Deporte { get; set; }
        public virtual DbSet<DeporteInscrito> DeporteInscrito { get; set; }
        public virtual DbSet<Horario> Horario { get; set; }
        public virtual DbSet<Profesores> Profesores { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Solicitud> Solicitud { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=Asura;Initial Catalog=SistemaDeportivoDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.HasKey(e => e.IdAdministrator)
                    .HasName("PK__Administ__336D26FEFB5814CC");

                entity.Property(e => e.IdAdministrator).HasColumnName("Id_Administrator");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Administrator)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_UserAdmin");
            });

            modelBuilder.Entity<Alumnos>(entity =>
            {
                entity.HasKey(e => e.IdAlumno)
                    .HasName("PK__Alumnos__B996CB1290E6F02C");

                entity.Property(e => e.IdAlumno).HasColumnName("Id_Alumno");

                entity.Property(e => e.ApellidoMat)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ApellidoPat)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Edad).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Alumnos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_UserAlumno");
            });

            modelBuilder.Entity<Credencial>(entity =>
            {
                entity.HasKey(e => e.IdCredencial)
                    .HasName("PK__Credenci__0E7E70885CD07575");

                entity.Property(e => e.IdCredencial).HasColumnName("Id_Credencial");

                entity.Property(e => e.IdAlumno).HasColumnName("Id_Alumno");

                entity.Property(e => e.IdProfesor).HasColumnName("Id_Profesor");

                entity.HasOne(d => d.IdAlumnoNavigation)
                    .WithMany(p => p.Credencial)
                    .HasForeignKey(d => d.IdAlumno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CredencialAlum");

                entity.HasOne(d => d.IdProfesorNavigation)
                    .WithMany(p => p.Credencial)
                    .HasForeignKey(d => d.IdProfesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CredencialProf");
            });

            modelBuilder.Entity<Deporte>(entity =>
            {
                entity.HasKey(e => e.IdDeporte)
                    .HasName("PK__Deporte__DE0349E2063F5981");

                entity.Property(e => e.IdDeporte).HasColumnName("Id_Deporte");

                entity.Property(e => e.IdHorario).HasColumnName("Id_Horario");

                entity.Property(e => e.NombreDeporte)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdHorarioNavigation)
                    .WithMany(p => p.Deporte)
                    .HasForeignKey(d => d.IdHorario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Horario");
            });

            modelBuilder.Entity<DeporteInscrito>(entity =>
            {
                entity.HasKey(e => e.IdDeporteInscrito)
                    .HasName("PK__DeporteI__DE6D85D7E9067EAA");

                entity.Property(e => e.IdDeporteInscrito).HasColumnName("Id_DeporteInscrito");

                entity.Property(e => e.IdAlumno).HasColumnName("Id_Alumno");

                entity.Property(e => e.IdDeporte).HasColumnName("Id_Deporte");

                entity.HasOne(d => d.IdAlumnoNavigation)
                    .WithMany(p => p.DeporteInscrito)
                    .HasForeignKey(d => d.IdAlumno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Inscrito_Alumno");

                entity.HasOne(d => d.IdDeporteNavigation)
                    .WithMany(p => p.DeporteInscrito)
                    .HasForeignKey(d => d.IdDeporte)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Inscrito_Deporte");
            });

            modelBuilder.Entity<Horario>(entity =>
            {
                entity.HasKey(e => e.IdHorario)
                    .HasName("PK__Horario__AD7A4DD39D83E66C");

                entity.Property(e => e.IdHorario).HasColumnName("Id_Horario");

                entity.Property(e => e.Jueves).HasMaxLength(30);

                entity.Property(e => e.Lunes).HasMaxLength(30);

                entity.Property(e => e.Marte).HasMaxLength(30);

                entity.Property(e => e.Miercoles).HasMaxLength(30);

                entity.Property(e => e.Viernes).HasMaxLength(30);
            });

            modelBuilder.Entity<Profesores>(entity =>
            {
                entity.HasKey(e => e.IdProfesor)
                    .HasName("PK__Profesor__45D4152A2BD98DD1");

                entity.Property(e => e.IdProfesor).HasColumnName("Id_Profesor");

                entity.Property(e => e.IdDeporte).HasColumnName("Id_Deporte");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdDeporteNavigation)
                    .WithMany(p => p.Profesores)
                    .HasForeignKey(d => d.IdDeporte)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DeporteProf");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Profesores)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_UserPrfosor");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Rol__55932E8618402999");

                entity.Property(e => e.IdRol).HasColumnName("Id_Rol");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Solicitud>(entity =>
            {
                entity.HasKey(e => e.IdSolicitud)
                    .HasName("PK__Solicitu__8791A50AEB575BC5");

                entity.Property(e => e.IdSolicitud).HasColumnName("Id_Solicitud");

                entity.Property(e => e.IdAlumno).HasColumnName("Id_Alumno");

                entity.Property(e => e.IdProfesor).HasColumnName("Id_Profesor");

                entity.HasOne(d => d.IdAlumnoNavigation)
                    .WithMany(p => p.Solicitud)
                    .HasForeignKey(d => d.IdAlumno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Solicitud_Alumno");

                entity.HasOne(d => d.IdProfesorNavigation)
                    .WithMany(p => p.Solicitud)
                    .HasForeignKey(d => d.IdProfesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Solicitud_Profesor");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__63C76BE2C2CBE3BF");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.IdRol).HasColumnName("Id_Rol");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Rol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
