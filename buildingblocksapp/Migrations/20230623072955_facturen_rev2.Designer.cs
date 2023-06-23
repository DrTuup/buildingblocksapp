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
    [Migration("20230623072955_facturen_rev2")]
    partial class facturen_rev2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("buildingblocksapp.Models.Betaling", b =>
                {
                    b.Property<int>("BetalingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BetalingId"));

                    b.Property<decimal>("Bedrag")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Betalingsdatum")
                        .HasColumnType("datetime2");

                    b.Property<int>("FactuurId")
                        .HasColumnType("int");

                    b.HasKey("BetalingId");

                    b.HasIndex("FactuurId");

                    b.ToTable("Betalingen");
                });

            modelBuilder.Entity("buildingblocksapp.Models.Factuur", b =>
                {
                    b.Property<int>("FactuurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FactuurId"));

                    b.Property<decimal>("BetaaldBedrag")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("FactuurStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("Factuurdatum")
                        .HasColumnType("datetime2");

                    b.Property<int>("KlantorderId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotaalBedrag")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("FactuurId");

                    b.HasIndex("KlantorderId")
                        .IsUnique();

                    b.ToTable("Facturen");
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

                    b.HasIndex("WerkorderId");

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

                    b.HasKey("WerkorderId");

                    b.HasIndex("KlantOrder");

                    b.ToTable("Werkorders");
                });

            modelBuilder.Entity("buildingblocksapp.Models.Betaling", b =>
                {
                    b.HasOne("buildingblocksapp.Models.Factuur", "Factuur")
                        .WithMany("Betalingen")
                        .HasForeignKey("FactuurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Factuur");
                });

            modelBuilder.Entity("buildingblocksapp.Models.Factuur", b =>
                {
                    b.HasOne("buildingblocksapp.Models.Klantorder", "Klantorder")
                        .WithOne("Factuur")
                        .HasForeignKey("buildingblocksapp.Models.Factuur", "KlantorderId")
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

            modelBuilder.Entity("buildingblocksapp.Models.Orderpick", b =>
                {
                    b.HasOne("buildingblocksapp.Models.Werkorder", "Werkorder")
                        .WithMany()
                        .HasForeignKey("WerkorderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Werkorder");
                });

            modelBuilder.Entity("buildingblocksapp.Models.Werkorder", b =>
                {
                    b.HasOne("buildingblocksapp.Models.Klantorder", "Klantorder")
                        .WithMany("Werkorders")
                        .HasForeignKey("KlantOrder")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Klantorder");
                });

            modelBuilder.Entity("buildingblocksapp.Models.Factuur", b =>
                {
                    b.Navigation("Betalingen");
                });

            modelBuilder.Entity("buildingblocksapp.Models.InkooporderCorrectie", b =>
                {
                    b.Navigation("Inkooporder")
                        .IsRequired();
                });

            modelBuilder.Entity("buildingblocksapp.Models.Klantorder", b =>
                {
                    b.Navigation("Factuur");

                    b.Navigation("Werkorders");
                });
#pragma warning restore 612, 618
        }
    }
}
