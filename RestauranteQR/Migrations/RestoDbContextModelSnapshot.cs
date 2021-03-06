// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestauranteQR.BaseDatos;

namespace RestauranteQR.Migrations
{
    [DbContext(typeof(RestoDbContext))]
    partial class RestoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("RestauranteQR.Models.IngredientePlato", b =>
                {
                    b.Property<int>("IngredienteId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlatoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("IngredienteId", "PlatoId");

                    b.HasIndex("PlatoId");

                    b.ToTable("IngredientePlato");
                });

            modelBuilder.Entity("RestauranteQR.Models.Mesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Activo")
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

                    b.Property<int?>("IngredienteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PedidoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Precio")
                        .HasColumnType("INTEGER");

                    b.Property<int>("cantMax")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IngredienteId");

                    b.HasIndex("PedidoId");

                    b.ToTable("Platos");
                });

            modelBuilder.Entity("RestauranteQR.Models.PlatosPorPedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MesaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NombrePlato")
                        .HasColumnType("TEXT");

                    b.Property<int>("PedidoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlatoId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("PrecioPlato")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("PlatosPorPedido");
                });

            modelBuilder.Entity("RestauranteQR.Models.IngredientePlato", b =>
                {
                    b.HasOne("RestauranteQR.Models.Ingrediente", "ElIngrediente")
                        .WithMany("IngredientePlatos")
                        .HasForeignKey("IngredienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestauranteQR.Models.Plato", "ElPlato")
                        .WithMany("IngredientePlatos")
                        .HasForeignKey("PlatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ElIngrediente");

                    b.Navigation("ElPlato");
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
                    b.HasOne("RestauranteQR.Models.Ingrediente", null)
                        .WithMany("Platos")
                        .HasForeignKey("IngredienteId");

                    b.HasOne("RestauranteQR.Models.Pedido", null)
                        .WithMany("Platos")
                        .HasForeignKey("PedidoId");
                });

            modelBuilder.Entity("RestauranteQR.Models.Ingrediente", b =>
                {
                    b.Navigation("IngredientePlatos");

                    b.Navigation("Platos");
                });

            modelBuilder.Entity("RestauranteQR.Models.Pedido", b =>
                {
                    b.Navigation("Platos");
                });

            modelBuilder.Entity("RestauranteQR.Models.Plato", b =>
                {
                    b.Navigation("IngredientePlatos");
                });
#pragma warning restore 612, 618
        }
    }
}
