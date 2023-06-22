using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace buildingblocksapp.Migrations
{
    /// <inheritdoc />
    public partial class add_factuur : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Factuur",
                columns: table => new
                {
                    FactuurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Factuurdatum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KlantorderId = table.Column<int>(type: "int", nullable: false),
                    TotaalBedrag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VoldaanBedrag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Betaaldatum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Betaalstatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factuur", x => x.FactuurId);
                    table.ForeignKey(
                        name: "FK_Factuur_Klantorders_KlantorderId",
                        column: x => x.KlantorderId,
                        principalTable: "Klantorders",
                        principalColumn: "KlantorderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Factuur_KlantorderId",
                table: "Factuur",
                column: "KlantorderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Factuur");
        }
    }
}
