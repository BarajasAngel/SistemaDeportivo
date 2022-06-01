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
        public virtual DbSet<Credential> Credential { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Sport> Sport { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<TimeTable> TimeTable { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=Asura;Initial Catalog=SistemaDeportivoDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.HasKey(e => e.IdAdministrator)
                    .HasName("PK__Administ__336D26FE88802BC1");

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

            modelBuilder.Entity<Credential>(entity =>
            {
                entity.HasKey(e => e.IdCredencial)
                    .HasName("PK__Credenti__27E40553353C3217");

                entity.Property(e => e.IdCredencial).HasColumnName("id_Credencial");

                entity.Property(e => e.IdAlumno).HasColumnName("Id_Alumno");

                entity.Property(e => e.IdProfesor).HasColumnName("Id_Profesor");

                entity.HasOne(d => d.IdAlumnoNavigation)
                    .WithMany(p => p.Credential)
                    .HasForeignKey(d => d.IdAlumno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CredencialAlum");

                entity.HasOne(d => d.IdProfesorNavigation)
                    .WithMany(p => p.Credential)
                    .HasForeignKey(d => d.IdProfesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CredencialProf");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Rol__55932E86C146F5FF");

                entity.Property(e => e.IdRol).HasColumnName("Id_Rol");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Sport>(entity =>
            {
                entity.HasKey(e => e.IdDeporte)
                    .HasName("PK__Sport__DE0349E2CA14CBB1");

                entity.Property(e => e.IdDeporte).HasColumnName("Id_Deporte");

                entity.Property(e => e.IdHorario).HasColumnName("Id_Horario");

                entity.Property(e => e.NombreDeporte)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdHorarioNavigation)
                    .WithMany(p => p.Sport)
                    .HasForeignKey(d => d.IdHorario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Horario");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.IdAlumno)
                    .HasName("PK__Students__B996CB12A81E6BA4");

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

                entity.Property(e => e.IdDeporte).HasColumnName("Id_Deporte");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.IdDeporteNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.IdDeporte)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Deporte");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_UserAlumno");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.IdProfesor)
                    .HasName("PK__Teacher__45D4152A1AD8D841");

                entity.Property(e => e.IdProfesor).HasColumnName("Id_Profesor");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Teacher)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_UserPrfosor");
            });

            modelBuilder.Entity<TimeTable>(entity =>
            {
                entity.HasKey(e => e.IdHorario)
                    .HasName("PK__TimeTabl__AD7A4DD341EC4629");

                entity.Property(e => e.IdHorario).HasColumnName("Id_Horario");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Users__63C76BE2A690F93D");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.IdRol).HasColumnName("Id_Rol");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Rol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
