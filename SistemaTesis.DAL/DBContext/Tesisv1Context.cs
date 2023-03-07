using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SistemaTesis.Entity.Models;

namespace SistemaTesis.DAL.DBContext;

public partial class Tesisv1Context : DbContext
{
    public Tesisv1Context()
    {
    }

    public Tesisv1Context(DbContextOptions<Tesisv1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Localidad> Localidades { get; set; }

    public virtual DbSet<Provincia> Provincias { get; set; }

    public virtual DbSet<Solicitud> Solicitudes { get; set; }

    public virtual DbSet<Solicitudesempleados> Solicitudesempleados { get; set; }

    public virtual DbSet<Solicitudestransportes> Solicitudestransportes { get; set; }

    public virtual DbSet<Tiposregistro> Tiposregistros { get; set; }

    public virtual DbSet<Transporte> Transportes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PRIMARY");

            entity.ToTable("clientes");

            entity.HasIndex(e => e.IdEstado, "clientes_estados_fk");

            entity.HasIndex(e => e.IdLocalidad, "clientes_localidades_fk");

            entity.HasIndex(e => e.IdTipoRegistro, "clientes_tiposregistros_fk");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(30)
                .HasColumnName("apellidos");
            entity.Property(e => e.Clave)
                .HasMaxLength(250)
                .HasColumnName("clave");
            entity.Property(e => e.Correo)
                .HasMaxLength(30)
                .HasColumnName("correo");
            entity.Property(e => e.DniCliente).HasColumnName("dniCliente");
            entity.Property(e => e.Domicilio)
                .HasMaxLength(40)
                .HasColumnName("domicilio");
            entity.Property(e => e.FechaNac).HasColumnName("fechaNac");
            entity.Property(e => e.IdEstado).HasColumnName("idEstado");
            entity.Property(e => e.IdLocalidad).HasColumnName("idLocalidad");
            entity.Property(e => e.IdTipoRegistro).HasColumnName("idTipoRegistro");
            entity.Property(e => e.Nombres)
                .HasMaxLength(30)
                .HasColumnName("nombres");
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("clientes_estados_fk");

            entity.HasOne(d => d.IdLocalidadNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdLocalidad)
                .HasConstraintName("clientes_localidades_fk");

            entity.HasOne(d => d.IdTipoRegistroNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdTipoRegistro)
                .HasConstraintName("clientes_tiposregistros_fk");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PRIMARY");

            entity.ToTable("empleados");

            entity.HasIndex(e => e.IdEstado, "empleados_estados_fk");

            entity.HasIndex(e => e.IdTipoRegistro, "empleados_tiposregistros_fk");

            entity.Property(e => e.IdEmpleado)
                .ValueGeneratedNever()
                .HasColumnName("idEmpleado");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(30)
                .HasColumnName("apellidos");
            entity.Property(e => e.Clave)
                .HasMaxLength(250)
                .HasColumnName("clave");
            entity.Property(e => e.Correo)
                .HasMaxLength(30)
                .HasColumnName("correo");
            entity.Property(e => e.DniEmpleado).HasColumnName("dniEmpleado");
            entity.Property(e => e.FechaNac).HasColumnName("fechaNac");
            entity.Property(e => e.IdEstado).HasColumnName("idEstado");
            entity.Property(e => e.IdTipoRegistro).HasColumnName("idTipoRegistro");
            entity.Property(e => e.Nombres)
                .HasMaxLength(30)
                .HasColumnName("nombres");
            entity.Property(e => e.PorcComision).HasColumnName("porcComision");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("empleados_estados_fk");

            entity.HasOne(d => d.IdTipoRegistroNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdTipoRegistro)
                .HasConstraintName("empleados_tiposregistros_fk");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PRIMARY");

            entity
                .ToTable("estados")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.IdTipoRegistro, "estados_tiposregistros_fk");

            entity.Property(e => e.IdEstado).HasColumnName("idEstado");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(30)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdTipoRegistro).HasColumnName("idTipoRegistro");

            entity.HasOne(d => d.IdTipoRegistroNavigation).WithMany(p => p.Estados)
                .HasForeignKey(d => d.IdTipoRegistro)
                .HasConstraintName("estados_tiposregistros_fk");
        });

        modelBuilder.Entity<Localidad>(entity =>
        {
            entity.HasKey(e => e.IdLocalidad).HasName("PRIMARY");

            entity.ToTable("localidades");

            entity.HasIndex(e => e.IdProvincia, "localidades_provincias_fk");

            entity.HasIndex(e => e.IdTipoRegistro, "localidades_tiposregistros_fk");

            entity.Property(e => e.IdLocalidad).HasColumnName("idLocalidad");
            entity.Property(e => e.IdProvincia).HasColumnName("idProvincia");
            entity.Property(e => e.IdTipoRegistro).HasColumnName("idTipoRegistro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdProvinciaNavigation).WithMany(p => p.Localidades)
                .HasForeignKey(d => d.IdProvincia)
                .HasConstraintName("localidades_provincias_fk");

            entity.HasOne(d => d.IdTipoRegistroNavigation).WithMany(p => p.Localidades)
                .HasForeignKey(d => d.IdTipoRegistro)
                .HasConstraintName("localidades_tiposregistros_fk");
        });

        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.HasKey(e => e.IdProvincia).HasName("PRIMARY");

            entity.ToTable("provincias");

            entity.HasIndex(e => e.IdTipoRegistro, "provincias_tiposregistros_fk");

            entity.Property(e => e.IdProvincia).HasColumnName("idProvincia");
            entity.Property(e => e.IdTipoRegistro).HasColumnName("idTipoRegistro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdTipoRegistroNavigation).WithMany(p => p.Provincia)
                .HasForeignKey(d => d.IdTipoRegistro)
                .HasConstraintName("provincias_tiposregistros_fk");
        });

        modelBuilder.Entity<Solicitud>(entity =>
        {
            entity.HasKey(e => e.IdSolicitud).HasName("PRIMARY");

            entity.ToTable("solicitudes");

            entity.HasIndex(e => e.IdCliente, "solicitudes_clientes_fk");

            entity.HasIndex(e => e.IdLocalidadDesde, "solicitudes_desde_fk");

            entity.HasIndex(e => e.IdEstado, "solicitudes_estados_fk");

            entity.HasIndex(e => e.IdLocalidadHasta, "solicitudes_hasta_fk");

            entity.HasIndex(e => e.IdTipoRegistro, "solicitudes_tiposregistros_fk");

            entity.Property(e => e.IdSolicitud)
                .ValueGeneratedNever()
                .HasColumnName("idSolicitud");
            entity.Property(e => e.CoordDesde)
                .HasMaxLength(50)
                .HasColumnName("coordDesde");
            entity.Property(e => e.CoordHasta)
                .HasMaxLength(50)
                .HasColumnName("coordHasta");
            entity.Property(e => e.FechaSolicitud).HasColumnName("fechaSolicitud");
            entity.Property(e => e.FechaTrabajo).HasColumnName("fechaTrabajo");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdEstado).HasColumnName("idEstado");
            entity.Property(e => e.IdLocalidadDesde).HasColumnName("idLocalidadDesde");
            entity.Property(e => e.IdLocalidadHasta).HasColumnName("idLocalidadHasta");
            entity.Property(e => e.IdTipoRegistro).HasColumnName("idTipoRegistro");
            entity.Property(e => e.PagoFaltante)
                .HasPrecision(6, 2)
                .HasColumnName("pagoFaltante");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Solicitudes)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("solicitudes_clientes_fk");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Solicitudes)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("solicitudes_estados_fk");

            entity.HasOne(d => d.IdLocalidadDesdeNavigation).WithMany(p => p.SolicitudeIdLocalidadDesdeNavigations)
                .HasForeignKey(d => d.IdLocalidadDesde)
                .HasConstraintName("solicitudes_desde_fk");

            entity.HasOne(d => d.IdLocalidadHastaNavigation).WithMany(p => p.SolicitudeIdLocalidadHastaNavigations)
                .HasForeignKey(d => d.IdLocalidadHasta)
                .HasConstraintName("solicitudes_hasta_fk");

            entity.HasOne(d => d.IdTipoRegistroNavigation).WithMany(p => p.Solicitudes)
                .HasForeignKey(d => d.IdTipoRegistro)
                .HasConstraintName("solicitudes_tiposregistros_fk");
        });

        modelBuilder.Entity<Solicitudesempleados>(entity =>
        {
            entity.HasKey(e => e.IdSe).HasName("PRIMARY");

            entity.ToTable("solicitudesempleados");

            entity.HasIndex(e => e.IdEmpleado, "se_empleados_fk");

            entity.HasIndex(e => e.IdSolicitud, "se_solicitudes_fk");

            entity.Property(e => e.IdSe)
                .ValueGeneratedNever()
                .HasColumnName("idSE");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.IdSolicitud).HasColumnName("idSolicitud");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Solicitudesempleados)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("se_empleados_fk");

            entity.HasOne(d => d.IdSolicitudNavigation).WithMany(p => p.Solicitudesempleados)
                .HasForeignKey(d => d.IdSolicitud)
                .HasConstraintName("se_solicitudes_fk");
        });

        modelBuilder.Entity<Solicitudestransportes>(entity =>
        {
            entity.HasKey(e => e.IdSt).HasName("PRIMARY");

            entity.ToTable("solicitudestransportes");

            entity.HasIndex(e => e.IdSolicitud, "st_solicitudes_fk");

            entity.HasIndex(e => e.IdTransporte, "st_transportes_fk");

            entity.Property(e => e.IdSt)
                .ValueGeneratedNever()
                .HasColumnName("idST");
            entity.Property(e => e.IdSolicitud).HasColumnName("idSolicitud");
            entity.Property(e => e.IdTransporte).HasColumnName("idTransporte");

            entity.HasOne(d => d.IdSolicitudNavigation).WithMany(p => p.Solicitudestransportes)
                .HasForeignKey(d => d.IdSolicitud)
                .HasConstraintName("st_solicitudes_fk");

            entity.HasOne(d => d.IdTransporteNavigation).WithMany(p => p.Solicitudestransportes)
                .HasForeignKey(d => d.IdTransporte)
                .HasConstraintName("st_transportes_fk");
        });

        modelBuilder.Entity<Tiposregistro>(entity =>
        {
            entity.HasKey(e => e.IdTipoRegistro).HasName("PRIMARY");

            entity
                .ToTable("tiposregistros")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.IdTipoRegistro).HasColumnName("idTipoRegistro");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(20)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Transporte>(entity =>
        {
            entity.HasKey(e => e.IdTransporte).HasName("PRIMARY");

            entity.ToTable("transportes");

            entity.HasIndex(e => e.IdEstado, "transportes_estados_fk");

            entity.HasIndex(e => e.IdTipoRegistro, "transportes_tiposregistros");

            entity.Property(e => e.IdTransporte).HasColumnName("idTransporte");
            entity.Property(e => e.Capacidad).HasColumnName("capacidad");
            entity.Property(e => e.IdEstado).HasColumnName("idEstado");
            entity.Property(e => e.IdTipoRegistro).HasColumnName("idTipoRegistro");
            entity.Property(e => e.Marca)
                .HasMaxLength(30)
                .HasColumnName("marca");
            entity.Property(e => e.Modelo).HasColumnName("modelo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .HasColumnName("nombre");
            entity.Property(e => e.Patente)
                .HasMaxLength(7)
                .HasColumnName("patente");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Transportes)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("transportes_estados_fk");

            entity.HasOne(d => d.IdTipoRegistroNavigation).WithMany(p => p.Transportes)
                .HasForeignKey(d => d.IdTipoRegistro)
                .HasConstraintName("transportes_tiposregistros");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
