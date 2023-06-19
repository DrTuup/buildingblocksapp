using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace buildingblocksapp.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InkooporderCorrecties",
                columns: table => new
                {
                    InkooporderCorrectieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rood = table.Column<int>(type: "int", nullable: false),
                    Grijs = table.Column<int>(type: "int", nullable: false),
                    Blauw = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InkooporderCorrecties", x => x.InkooporderCorrectieId);
                });

            migrationBuilder.CreateTable(
                name: "Inkooporders",
                columns: table => new
                {
                    InkooporderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InkooporderCorrectieId = table.Column<int>(type: "int", nullable: false),
                    PeriodeBinnenkomst = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodeVerwerkt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rood = table.Column<int>(type: "int", nullable: false),
                    Grijs = table.Column<int>(type: "int", nullable: false),
                    Blauw = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inkooporders", x => x.InkooporderId);
                });

            migrationBuilder.CreateTable(
                name: "Klantorders",
                columns: table => new
                {
                    KlantorderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aantal = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Referentienummer = table.Column<int>(type: "int", nullable: false),
                    AkkoordAccountmanager = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klantorders", x => x.KlantorderId);
                });

            migrationBuilder.CreateTable(
                name: "Orderpicks",
                columns: table => new
                {
                    OrderpickId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WerkorderId = table.Column<int>(type: "int", nullable: false),
                    PeriodeAanvraag = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodeLevering = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rood = table.Column<int>(type: "int", nullable: false),
                    Grijs = table.Column<int>(type: "int", nullable: false),
                    Blauw = table.Column<int>(type: "int", nullable: false),
                    AkkoordProductie = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orderpicks", x => x.OrderpickId);
                });

            migrationBuilder.CreateTable(
                name: "InkooporderInkooporderCorrectie",
                columns: table => new
                {
                    InkooporderCorrectiesInkooporderCorrectieId = table.Column<int>(type: "int", nullable: false),
                    InkoopordersInkooporderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InkooporderInkooporderCorrectie", x => new { x.InkooporderCorrectiesInkooporderCorrectieId, x.InkoopordersInkooporderId });
                    table.ForeignKey(
                        name: "FK_InkooporderInkooporderCorrectie_InkooporderCorrecties_InkooporderCorrectiesInkooporderCorrectieId",
                        column: x => x.InkooporderCorrectiesInkooporderCorrectieId,
                        principalTable: "InkooporderCorrecties",
                        principalColumn: "InkooporderCorrectieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InkooporderInkooporderCorrectie_Inkooporders_InkoopordersInkooporderId",
                        column: x => x.InkoopordersInkooporderId,
                        principalTable: "Inkooporders",
                        principalColumn: "InkooporderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Werkorders",
                columns: table => new
                {
                    WerkorderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderpickId = table.Column<int>(type: "int", nullable: false),
                    KlantOrder = table.Column<int>(type: "int", nullable: false),
                    Productielijn = table.Column<int>(type: "int", nullable: false),
                    LeverPeriode = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AkkoordPanning = table.Column<bool>(type: "bit", nullable: false),
                    AkkoordAccountmanager = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Werkorders", x => x.WerkorderId);
                    table.ForeignKey(
                        name: "FK_Werkorders_Klantorders_KlantOrder",
                        column: x => x.KlantOrder,
                        principalTable: "Klantorders",
                        principalColumn: "KlantorderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Werkorders_Orderpicks_OrderpickId",
                        column: x => x.OrderpickId,
                        principalTable: "Orderpicks",
                        principalColumn: "OrderpickId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InkooporderInkooporderCorrectie_InkoopordersInkooporderId",
                table: "InkooporderInkooporderCorrectie",
                column: "InkoopordersInkooporderId");

            migrationBuilder.CreateIndex(
                name: "IX_Werkorders_KlantOrder",
                table: "Werkorders",
                column: "KlantOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Werkorders_OrderpickId",
                table: "Werkorders",
                column: "OrderpickId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InkooporderInkooporderCorrectie");

            migrationBuilder.DropTable(
                name: "Werkorders");

            migrationBuilder.DropTable(
                name: "InkooporderCorrecties");

            migrationBuilder.DropTable(
                name: "Inkooporders");

            migrationBuilder.DropTable(
                name: "Klantorders");

            migrationBuilder.DropTable(
                name: "Orderpicks");
        }
    }
}
