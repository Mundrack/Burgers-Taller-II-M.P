﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MateoPugaProyectoII.Migrations
{
    [DbContext(typeof(MateoPugaDB))]
    partial class MateoPugaDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MateoPugaProyectoII.Models.Burger", b =>
                {
                    b.Property<int>("BurgerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BurgerID"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("WithChees")
                        .HasColumnType("bit");

                    b.HasKey("BurgerID");

                    b.ToTable("Burger");
                });

            modelBuilder.Entity("MateoPugaProyectoII.Models.Promo", b =>
                {
                    b.Property<int>("PromoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PromoID"));

                    b.Property<int>("BurgerID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaPromo")
                        .HasColumnType("datetime2");

                    b.HasKey("PromoID");

                    b.HasIndex("BurgerID");

                    b.ToTable("Promo");
                });

            modelBuilder.Entity("MateoPugaProyectoII.Models.Promo", b =>
                {
                    b.HasOne("MateoPugaProyectoII.Models.Burger", "Burger")
                        .WithMany("promos")
                        .HasForeignKey("BurgerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Burger");
                });

            modelBuilder.Entity("MateoPugaProyectoII.Models.Burger", b =>
                {
                    b.Navigation("promos");
                });
#pragma warning restore 612, 618
        }
    }
}
