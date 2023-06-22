﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using buildingblocksapp;

#nullable disable

namespace buildingblocksapp.Migrations
{
    [DbContext(typeof(BuildingblocksContext))]
    partial class BuildingblocksContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("buildingblocksapp.Models.Factuur", b =>
                {
                    b.Property<int>("FactuurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FactuurId"));

                    b.Property<string>("Betaaldatum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Betaalstatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Factuurdatum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KlantorderId")
                        .HasColumnType("int");

                    b.Property<string>("TotaalBedrag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VoldaanBedrag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FactuurId");

                    b.HasIndex("KlantorderId");

                    b.ToTable("Factuur");
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

                    b.HasIndex("InkooporderCorrectieId")
                        .IsUnique();

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

                    b.Property<int>("InkooporderId")
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

                    b.Property<DateTime>("AanmaakDatum")
                        .HasColumnType("datetime2");

                    b.Property<int>("Aantal")
                        .HasColumnType("int");

                    b.Property<bool>("AkkoordAccountmanager")
                        .HasColumnType("bit");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Referentienummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime>("VertrekDatum")
                        .HasColumnType("datetime2");

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

                    b.Property<bool>("AkkoordPanning")
                        .HasColumnType("bit");

                    b.Property<int>("KlantOrder")
                        .HasColumnType("int");

                    b.Property<DateTime>("LeverPeriode")
                        .HasColumnType("datetime2");

                    b.Property<int>("Motortype")
                        .HasColumnType("int");

                    b.Property<int>("OrderpickId")
                        .HasColumnType("int");

                    b.HasKey("WerkorderId");

                    b.HasIndex("KlantOrder");

                    b.HasIndex("OrderpickId")
                        .IsUnique();

                    b.ToTable("Werkorders");
                });

            modelBuilder.Entity("buildingblocksapp.Models.Factuur", b =>
                {
                    b.HasOne("buildingblocksapp.Models.Klantorder", "Klantorder")
                        .WithMany()
                        .HasForeignKey("KlantorderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Klantorder");
                });

            modelBuilder.Entity("buildingblocksapp.Models.Inkooporder", b =>
                {
                    b.HasOne("buildingblocksapp.Models.InkooporderCorrectie", "InkooporderCorrectie")
                        .WithOne("Inkooporder")
                        .HasForeignKey("buildingblocksapp.Models.Inkooporder", "InkooporderCorrectieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InkooporderCorrectie");
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

            modelBuilder.Entity("buildingblocksapp.Models.InkooporderCorrectie", b =>
                {
                    b.Navigation("Inkooporder")
                        .IsRequired();
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
