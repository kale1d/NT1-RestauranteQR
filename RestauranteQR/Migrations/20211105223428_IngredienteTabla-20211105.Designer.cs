﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestauranteQR.BaseDatos;

namespace RestauranteQR.Migrations
{
    [DbContext(typeof(RestoDbContext))]
    [Migration("20211105223428_IngredienteTabla-20211105")]
    partial class IngredienteTabla20211105
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("RestauranteQR.Models.Administrador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellido")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Administradores");
                });

            modelBuilder.Entity("RestauranteQR.Models.Ingrediente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Ingredientes");
                });

            modelBuilder.Entity("RestauranteQR.Models.IngredientePorPlato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IngredienteId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlatoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("IngredientesPorPlatos");
                });

            modelBuilder.Entity("RestauranteQR.Models.Mesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Activo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Mesa");
                });

            modelBuilder.Entity("RestauranteQR.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MesaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MesaId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("RestauranteQR.Models.Plato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("IngredienteId1")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("IngredienteId2")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PedidoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Precio")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.ToTable("Platos");
                });

            modelBuilder.Entity("RestauranteQR.Models.Pedido", b =>
                {
                    b.HasOne("RestauranteQR.Models.Mesa", "Mesa")
                        .WithMany()
                        .HasForeignKey("MesaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mesa");
                });

            modelBuilder.Entity("RestauranteQR.Models.Plato", b =>
                {
                    b.HasOne("RestauranteQR.Models.Pedido", null)
                        .WithMany("Platos")
                        .HasForeignKey("PedidoId");
                });

            modelBuilder.Entity("RestauranteQR.Models.Pedido", b =>
                {
                    b.Navigation("Platos");
                });
#pragma warning restore 612, 618
        }
    }
}
