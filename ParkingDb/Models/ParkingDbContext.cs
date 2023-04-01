using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ParkingDb.Models;

public partial class ParkingDbContext : DbContext
{
    public ParkingDbContext()
    {
    }

    public ParkingDbContext(DbContextOptions<ParkingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ingreso> Ingresos { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }

    public virtual DbSet<TipoVehiculo> TipoVehiculos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                => optionsBuilder.UseSqlServer("server=DESKTOP-E7AGSG4\\SQLEXPRESS; database=ParkingDB; integrated security=true; Encrypt=False");
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ingreso>(entity =>
        {
            entity.HasKey(e => e.IdIngreso);

            entity.ToTable("Ingreso");

            entity.HasIndex(e => e.IdIngreso, "IX_Ingreso");

            entity.Property(e => e.IdIngreso)
                .ValueGeneratedNever()
                .HasColumnName("idIngreso");
            entity.Property(e => e.FechaIngreso)
                .HasColumnType("date")
                .HasColumnName("fechaIngreso");
            entity.Property(e => e.FechaSalida)
                .HasColumnType("date")
                .HasColumnName("fechaSalida");
            entity.Property(e => e.HoraIngreso).HasColumnName("horaIngreso");
            entity.Property(e => e.HoraSalida).HasColumnName("horaSalida");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.IdVehiculo).HasColumnName("idVehiculo");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Ingresos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_Ingreso_Usuario");

            entity.HasOne(d => d.IdVehiculoNavigation).WithMany(p => p.Ingresos)
                .HasForeignKey(d => d.IdVehiculo)
                .HasConstraintName("FK_Ingreso_Vehiculo");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.IdMarca);

            entity.ToTable("Marca");

            entity.Property(e => e.IdMarca)
                .ValueGeneratedNever()
                .HasColumnName("idMarca");
            entity.Property(e => e.NombreMarca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreMarca");
        });

        modelBuilder.Entity<TipoUsuario>(entity =>
        {
            entity.HasKey(e => e.IdTipoUsuario);

            entity.ToTable("TipoUsuario");

            entity.Property(e => e.IdTipoUsuario)
                .ValueGeneratedNever()
                .HasColumnName("idTipoUsuario");
            entity.Property(e => e.NombreTipoUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreTipoUsuario");
        });

        modelBuilder.Entity<TipoVehiculo>(entity =>
        {
            entity.HasKey(e => e.IdTipo);

            entity.ToTable("tipoVehiculo");

            entity.Property(e => e.IdTipo)
                .ValueGeneratedNever()
                .HasColumnName("idTipo");
            entity.Property(e => e.NombreTipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreTipo");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario)
                .ValueGeneratedNever()
                .HasColumnName("idUsuario");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTipoUsuarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdTipoUsuario)
                .HasConstraintName("FK_Usuario_TipoUsuario");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.IdVehiculo);

            entity.ToTable("Vehiculo");

            entity.Property(e => e.IdVehiculo)
                .ValueGeneratedNever()
                .HasColumnName("idVehiculo");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("color");
            entity.Property(e => e.Documento).HasColumnName("documento");
            entity.Property(e => e.IdMarca).HasColumnName("idMarca");
            entity.Property(e => e.IdTipo).HasColumnName("idTipo");
            entity.Property(e => e.Placa)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("placa");

            entity.HasOne(d => d.IdMarcaNavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.IdMarca)
                .HasConstraintName("FK_Vehiculo_Marca");

            entity.HasOne(d => d.IdTipoNavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.IdTipo)
                .HasConstraintName("FK_Vehiculo_tipoVehiculo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
