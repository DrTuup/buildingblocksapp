using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace buildingblocksapp.Migrations
{
    /// <inheritdoc />
    public partial class fix_werkorder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AkkoordAccountmanager",
                table: "Werkorders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AkkoordAccountmanager",
                table: "Werkorders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
