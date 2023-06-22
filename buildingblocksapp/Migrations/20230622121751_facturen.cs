using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace buildingblocksapp.Migrations
{
    /// <inheritdoc />
    public partial class facturen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factuur_Klantorders_KlantorderId",
                table: "Factuur");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Factuur",
                table: "Factuur");

            migrationBuilder.RenameTable(
                name: "Factuur",
                newName: "Facturen");

            migrationBuilder.RenameIndex(
                name: "IX_Factuur_KlantorderId",
                table: "Facturen",
                newName: "IX_Facturen_KlantorderId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Factuurdatum",
                table: "Facturen",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Facturen",
                table: "Facturen",
                column: "FactuurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturen_Klantorders_KlantorderId",
                table: "Facturen",
                column: "KlantorderId",
                principalTable: "Klantorders",
                principalColumn: "KlantorderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturen_Klantorders_KlantorderId",
                table: "Facturen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Facturen",
                table: "Facturen");

            migrationBuilder.RenameTable(
                name: "Facturen",
                newName: "Factuur");

            migrationBuilder.RenameIndex(
                name: "IX_Facturen_KlantorderId",
                table: "Factuur",
                newName: "IX_Factuur_KlantorderId");

            migrationBuilder.AlterColumn<string>(
                name: "Factuurdatum",
                table: "Factuur",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Factuur",
                table: "Factuur",
                column: "FactuurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Factuur_Klantorders_KlantorderId",
                table: "Factuur",
                column: "KlantorderId",
                principalTable: "Klantorders",
                principalColumn: "KlantorderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
