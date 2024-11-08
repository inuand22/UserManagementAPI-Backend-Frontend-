﻿// <auto-generated />
using System;
using LogicaDatos.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LogicaDatos.Migrations
{
    [DbContext(typeof(GestionUsuariosContext))]
    partial class GestionUsuariosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LogicaNegocio.EntidadesDominio.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaEvento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<int>("TipoTramiteId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoTramiteId");

                    b.HasIndex("UserId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("LogicaNegocio.EntidadesDominio.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("LogicaNegocio.EntidadesDominio.TipoTramite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("TiposTramites");
                });

            modelBuilder.Entity("LogicaNegocio.EntidadesDominio.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("RolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RolId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("LogicaNegocio.EntidadesDominio.Evento", b =>
                {
                    b.HasOne("LogicaNegocio.EntidadesDominio.TipoTramite", "TipoTramite")
                        .WithMany()
                        .HasForeignKey("TipoTramiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogicaNegocio.EntidadesDominio.Usuario", "User")
                        .WithMany("Eventos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("LogicaNegocio.ValueObjects.DescripcionEvento", "Descripcion", b1 =>
                        {
                            b1.Property<int>("EventoId")
                                .HasColumnType("int");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("EventoId");

                            b1.ToTable("Eventos");

                            b1.WithOwner()
                                .HasForeignKey("EventoId");
                        });

                    b.Navigation("Descripcion")
                        .IsRequired();

                    b.Navigation("TipoTramite");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LogicaNegocio.EntidadesDominio.Rol", b =>
                {
                    b.OwnsOne("LogicaNegocio.ValueObjects.NombreRol", "Nombre", b1 =>
                        {
                            b1.Property<int>("RolId")
                                .HasColumnType("int");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("RolId");

                            b1.ToTable("Roles");

                            b1.WithOwner()
                                .HasForeignKey("RolId");
                        });

                    b.Navigation("Nombre")
                        .IsRequired();
                });

            modelBuilder.Entity("LogicaNegocio.EntidadesDominio.TipoTramite", b =>
                {
                    b.OwnsOne("LogicaNegocio.ValueObjects.NombreTipoTramite", "Nombre", b1 =>
                        {
                            b1.Property<int>("TipoTramiteId")
                                .HasColumnType("int");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("TipoTramiteId");

                            b1.ToTable("TiposTramites");

                            b1.WithOwner()
                                .HasForeignKey("TipoTramiteId");
                        });

                    b.Navigation("Nombre")
                        .IsRequired();
                });

            modelBuilder.Entity("LogicaNegocio.EntidadesDominio.Usuario", b =>
                {
                    b.HasOne("LogicaNegocio.EntidadesDominio.Rol", "Rol")
                        .WithMany("Usuarios")
                        .HasForeignKey("RolId");

                    b.OwnsOne("LogicaNegocio.ValueObjects.ApellidoUsuario", "Apellido", b1 =>
                        {
                            b1.Property<int>("UsuarioId")
                                .HasColumnType("int");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuarios");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.OwnsOne("LogicaNegocio.ValueObjects.CiUsuario", "Ci", b1 =>
                        {
                            b1.Property<int>("UsuarioId")
                                .HasColumnType("int");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuarios");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.OwnsOne("LogicaNegocio.ValueObjects.EmailUsuario", "Email", b1 =>
                        {
                            b1.Property<int>("UsuarioId")
                                .HasColumnType("int");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuarios");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.OwnsOne("LogicaNegocio.ValueObjects.NombreUsuario", "Nombre", b1 =>
                        {
                            b1.Property<int>("UsuarioId")
                                .HasColumnType("int");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuarios");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.OwnsOne("LogicaNegocio.ValueObjects.PasswordUsuario", "Pass", b1 =>
                        {
                            b1.Property<int>("UsuarioId")
                                .HasColumnType("int");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuarios");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.OwnsOne("LogicaNegocio.ValueObjects.TelefonoUsuario", "Telefono", b1 =>
                        {
                            b1.Property<int>("UsuarioId")
                                .HasColumnType("int");

                            b1.Property<int>("Valor")
                                .HasColumnType("int");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuarios");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.Navigation("Apellido")
                        .IsRequired();

                    b.Navigation("Ci")
                        .IsRequired();

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Nombre")
                        .IsRequired();

                    b.Navigation("Pass")
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("Telefono")
                        .IsRequired();
                });

            modelBuilder.Entity("LogicaNegocio.EntidadesDominio.Rol", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("LogicaNegocio.EntidadesDominio.Usuario", b =>
                {
                    b.Navigation("Eventos");
                });
#pragma warning restore 612, 618
        }
    }
}
