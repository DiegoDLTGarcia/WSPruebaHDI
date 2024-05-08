using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WSPruebaHDI.Models
{
    public partial class CatalogoMascotasContext : DbContext
    {
        public CatalogoMascotasContext()
        {
        }

        public CatalogoMascotasContext(DbContextOptions<CatalogoMascotasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Especie> Especies { get; set; } = null!;
        public virtual DbSet<Mascota> Mascotas { get; set; } = null!;
        public virtual DbSet<Propietario> Propietarios { get; set; } = null!;
        public virtual DbSet<Raza> Razas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Especie>(entity =>
            {
                entity.HasKey(e => e.IdEspecie)
                    .HasName("PK__Especies__96DDB0B951A75880");

                entity.Property(e => e.IdEspecie).HasColumnName("id_especie");

                entity.Property(e => e.NombreEspecie)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_especie");
            });

            modelBuilder.Entity<Mascota>(entity =>
            {
                entity.HasKey(e => e.IdMascota)
                    .HasName("PK__Mascotas__6F037352E527E7F2");

                entity.Property(e => e.IdMascota).HasColumnName("id_mascota");

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.IdPropietario).HasColumnName("id_propietario");

                entity.Property(e => e.IdRaza).HasColumnName("id_raza");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.objPropietario)
                    .WithMany(p => p.Mascota)
                    .HasForeignKey(d => d.IdPropietario)
                    .HasConstraintName("FK__Mascotas__id_pro__5070F446");

                entity.HasOne(d => d.objRaza)
                    .WithMany(p => p.Mascota)
                    .HasForeignKey(d => d.IdRaza)
                    .HasConstraintName("FK__Mascotas__id_raz__5165187F");
            });

            modelBuilder.Entity<Propietario>(entity =>
            {
                entity.HasKey(e => e.IdPropietario)
                    .HasName("PK__Propieta__D2E5693719328072");

                entity.Property(e => e.IdPropietario).HasColumnName("id_propietario");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("correo_electronico");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<Raza>(entity =>
            {
                entity.HasKey(e => e.IdRaza)
                    .HasName("PK__Razas__084F250A2FA252E3");

                entity.Property(e => e.IdRaza).HasColumnName("id_raza");

                entity.Property(e => e.IdEspecie).HasColumnName("id_especie");

                entity.Property(e => e.NombreRaza)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_raza");

                entity.HasOne(d => d.objEspecie)
                    .WithMany(p => p.Razas)
                    .HasForeignKey(d => d.IdEspecie)
                    .HasConstraintName("FK__Razas__id_especi__4D94879B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
