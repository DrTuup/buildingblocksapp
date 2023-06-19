using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace buildingblocksapp.Migrations
{
    /// <inheritdoc />
    public partial class fix_inkooporder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InkooporderInkooporderCorrectie");

            migrationBuilder.AddColumn<int>(
                name: "InkooporderId",
                table: "InkooporderCorrecties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Inkooporders_InkooporderCorrectieId",
                table: "Inkooporders",
                column: "InkooporderCorrectieId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Inkooporders_InkooporderCorrecties_InkooporderCorrectieId",
                table: "Inkooporders",
                column: "InkooporderCorrectieId",
                principalTable: "InkooporderCorrecties",
                principalColumn: "InkooporderCorrectieId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inkooporders_InkooporderCorrecties_InkooporderCorrectieId",
                table: "Inkooporders");

            migrationBuilder.DropIndex(
                name: "IX_Inkooporders_InkooporderCorrectieId",
                table: "Inkooporders");

            migrationBuilder.DropColumn(
                name: "InkooporderId",
                table: "InkooporderCorrecties");

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

            migrationBuilder.CreateIndex(
                name: "IX_InkooporderInkooporderCorrectie_InkoopordersInkooporderId",
                table: "InkooporderInkooporderCorrectie",
                column: "InkoopordersInkooporderId");
        }
    }
}
