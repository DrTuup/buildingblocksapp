using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace buildingblocksapp.Migrations
{
    /// <inheritdoc />
    public partial class facturen_rev2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Facturen_KlantorderId",
                table: "Facturen");

            migrationBuilder.DropColumn(
                name: "Betaaldatum",
                table: "Facturen");

            migrationBuilder.DropColumn(
                name: "Betaalstatus",
                table: "Facturen");

            migrationBuilder.DropColumn(
                name: "VoldaanBedrag",
                table: "Facturen");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotaalBedrag",
                table: "Facturen",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<decimal>(
                name: "BetaaldBedrag",
                table: "Facturen",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "FactuurStatus",
                table: "Facturen",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Betalingen",
                columns: table => new
                {
                    BetalingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Betalingsdatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Bedrag = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FactuurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Betalingen", x => x.BetalingId);
                    table.ForeignKey(
                        name: "FK_Betalingen_Facturen_FactuurId",
                        column: x => x.FactuurId,
                        principalTable: "Facturen",
                        principalColumn: "FactuurId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Facturen_KlantorderId",
                table: "Facturen",
                column: "KlantorderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Betalingen_FactuurId",
                table: "Betalingen",
                column: "FactuurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Betalingen");

            migrationBuilder.DropIndex(
                name: "IX_Facturen_KlantorderId",
                table: "Facturen");

            migrationBuilder.DropColumn(
                name: "BetaaldBedrag",
                table: "Facturen");

            migrationBuilder.DropColumn(
                name: "FactuurStatus",
                table: "Facturen");

            migrationBuilder.AlterColumn<string>(
                name: "TotaalBedrag",
                table: "Facturen",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "Betaaldatum",
                table: "Facturen",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Betaalstatus",
                table: "Facturen",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VoldaanBedrag",
                table: "Facturen",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Facturen_KlantorderId",
                table: "Facturen",
                column: "KlantorderId");
        }
    }
}
