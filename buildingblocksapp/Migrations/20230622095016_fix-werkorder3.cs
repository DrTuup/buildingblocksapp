using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace buildingblocksapp.Migrations
{
    /// <inheritdoc />
    public partial class fixwerkorder3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Werkorders_Orderpicks_OrderpickId",
                table: "Werkorders");

            migrationBuilder.DropIndex(
                name: "IX_Werkorders_OrderpickId",
                table: "Werkorders");

            migrationBuilder.DropColumn(
                name: "OrderpickId",
                table: "Werkorders");

            migrationBuilder.CreateIndex(
                name: "IX_Orderpicks_WerkorderId",
                table: "Orderpicks",
                column: "WerkorderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orderpicks_Werkorders_WerkorderId",
                table: "Orderpicks",
                column: "WerkorderId",
                principalTable: "Werkorders",
                principalColumn: "WerkorderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orderpicks_Werkorders_WerkorderId",
                table: "Orderpicks");

            migrationBuilder.DropIndex(
                name: "IX_Orderpicks_WerkorderId",
                table: "Orderpicks");

            migrationBuilder.AddColumn<int>(
                name: "OrderpickId",
                table: "Werkorders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Werkorders_OrderpickId",
                table: "Werkorders",
                column: "OrderpickId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Werkorders_Orderpicks_OrderpickId",
                table: "Werkorders",
                column: "OrderpickId",
                principalTable: "Orderpicks",
                principalColumn: "OrderpickId");
        }
    }
}
