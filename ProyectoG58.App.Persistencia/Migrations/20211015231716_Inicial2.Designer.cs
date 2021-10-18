﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoG58.App.Persistencia;

namespace ProyectoG58.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20211015231716_Inicial2")]
    partial class Inicial2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ProyectoG58.App.Dominio.Bodega", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Bodega");
                });

            modelBuilder.Entity("ProyectoG58.App.Dominio.Cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("identificacion")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("ProyectoG58.App.Dominio.Empleado", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("cargo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("identificacion")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Empleado");
                });

            modelBuilder.Entity("ProyectoG58.App.Dominio.Estado", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fechaRegistro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("ProyectoG58.App.Dominio.Factura", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("clienteId")
                        .HasColumnType("int");

                    b.Property<int>("empleadoId")
                        .HasColumnType("int");

                    b.Property<string>("estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fecha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("saldo")
                        .HasColumnType("float");

                    b.Property<int>("tipo")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Factura");
                });

            modelBuilder.Entity("ProyectoG58.App.Dominio.OrdenCompra", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("bodegaId")
                        .HasColumnType("int");

                    b.Property<string>("estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fecha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("proveedorId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("OrdenCompra");
                });

            modelBuilder.Entity("ProyectoG58.App.Dominio.OrdenProducto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<double>("iva")
                        .HasColumnType("float");

                    b.Property<int>("ordenCompraId")
                        .HasColumnType("int");

                    b.Property<int>("productoId")
                        .HasColumnType("int");

                    b.Property<double>("valor")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.ToTable("OrdenProducto");
                });

            modelBuilder.Entity("ProyectoG58.App.Dominio.Producto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<string>("estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fechaVencim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("presentacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("ProyectoG58.App.Dominio.ProductoFactura", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<int>("facturaId")
                        .HasColumnType("int");

                    b.Property<double>("iva")
                        .HasColumnType("float");

                    b.Property<int>("productoId")
                        .HasColumnType("int");

                    b.Property<double>("valor")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.ToTable("ProductoFactura");
                });

            modelBuilder.Entity("ProyectoG58.App.Dominio.Proveedor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("nit")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Proveedor");
                });

            modelBuilder.Entity("ProyectoG58.App.Dominio.TipoFactura", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fechaRegistro")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("TipoFactura");
                });
#pragma warning restore 612, 618
        }
    }
}
