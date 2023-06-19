﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using buildingblocksapp;

#nullable disable

namespace buildingblocksapp.Migrations
{
    [DbContext(typeof(BuildingblocksContext))]
    [Migration("20230619123444_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InkooporderInkooporderCorrectie", b =>
                {
                    b.Property<int>("InkooporderCorrectiesInkooporderCorrectieId")
                        .HasColumnType("int");

                    b.Property<int>("InkoopordersInkooporderId")
                        .HasColumnType("int");

                    b.HasKey("InkooporderCorrectiesInkooporderCorrectieId", "InkoopordersInkooporderId");

                    b.HasIndex("InkoopordersInkooporderId");

                    b.ToTable("InkooporderInkooporderCorrectie");
                });

            modelBuilder.Entity("buildingblocksapp.Models.Inkooporder", b =>
                {
                    b.Property<int>("InkooporderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InkooporderId"));

                    b.Property<int>("Blauw")
                        .HasColumnType("int");

                    b.Property<int>("Grijs")
                        .HasColumnType("int");

                    b.Property<int>("InkooporderCorrectieId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PeriodeBinnenkomst")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PeriodeVerwerkt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Rood")
                        .HasColumnType("int");

                    b.HasKey("InkooporderId");

                    b.ToTable("Inkooporders");
                });

            modelBuilder.Entity("buildingblocksapp.Models.InkooporderCorrectie", b =>
                {
                    b.Property<int>("InkooporderCorrectieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InkooporderCorrectieId"));

                    b.Property<int>("Blauw")
                        .HasColumnType("int");

                    b.Property<int>("Grijs")
                        .HasColumnType("int");

                    b.Property<int>("Rood")
                        .HasColumnType("int");

                    b.HasKey("InkooporderCorrectieId");

                    b.ToTable("InkooporderCorrecties");
                });

            modelBuilder.Entity("buildingblocksapp.Models.Klantorder", b =>
                {
                    b.Property<int>("KlantorderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KlantorderId"));

                    b.Property<int>("Aantal")
                        .HasColumnType("int");

                    b.Property<bool>("AkkoordAccountmanager")
                        .HasColumnType("bit");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Referentienummer")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KlantorderId");

                    b.ToTable("Klantorders");
                });

            modelBuilder.Entity("buildingblocksapp.Models.Orderpick", b =>
                {
                    b.Property<int>("OrderpickId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderpickId"));

                    b.Property<bool>("AkkoordProductie")
                        .HasColumnType("bit");

                    b.Property<int>("Blauw")
                        .HasColumnType("int");

                    b.Property<int>("Grijs")
                        .HasColumnType("int");

                    b.Property<DateTime>("PeriodeAanvraag")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PeriodeLevering")
                        .HasColumnType("datetime2");

                    b.Property<int>("Rood")
                        .HasColumnType("int");

                    b.Property<int>("WerkorderId")
                        .HasColumnType("int");

                    b.HasKey("OrderpickId");

                    b.ToTable("Orderpicks");
                });

            modelBuilder.Entity("buildingblocksapp.Models.Werkorder", b =>
                {
                    b.Property<int>("WerkorderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WerkorderId"));

                    b.Property<bool>("AkkoordAccountmanager")
                        .HasColumnType("bit");

                    b.Property<bool>("AkkoordPanning")
                        .HasColumnType("bit");

                    b.Property<int>("KlantOrder")
                        .HasColumnType("int");

                    b.Property<DateTime>("LeverPeriode")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderpickId")
                        .HasColumnType("int");

                    b.Property<int>("Productielijn")
                        .HasColumnType("int");

                    b.HasKey("WerkorderId");

                    b.HasIndex("KlantOrder");

                    b.HasIndex("OrderpickId")
                        .IsUnique();

                    b.ToTable("Werkorders");
                });

            modelBuilder.Entity("InkooporderInkooporderCorrectie", b =>
                {
                    b.HasOne("buildingblocksapp.Models.InkooporderCorrectie", null)
                        .WithMany()
                        .HasForeignKey("InkooporderCorrectiesInkooporderCorrectieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("buildingblocksapp.Models.Inkooporder", null)
                        .WithMany()
                        .HasForeignKey("InkoopordersInkooporderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("buildingblocksapp.Models.Werkorder", b =>
                {
                    b.HasOne("buildingblocksapp.Models.Klantorder", "Klantorder")
                        .WithMany("Werkorders")
                        .HasForeignKey("KlantOrder")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("buildingblocksapp.Models.Orderpick", "Orderpick")
                        .WithOne("Werkorder")
                        .HasForeignKey("buildingblocksapp.Models.Werkorder", "OrderpickId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Klantorder");

                    b.Navigation("Orderpick");
                });

            modelBuilder.Entity("buildingblocksapp.Models.Klantorder", b =>
                {
                    b.Navigation("Werkorders");
                });

            modelBuilder.Entity("buildingblocksapp.Models.Orderpick", b =>
                {
                    b.Navigation("Werkorder")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
