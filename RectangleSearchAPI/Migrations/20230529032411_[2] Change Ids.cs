using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RectangleSearchAPI.Migrations
{
    /// <inheritdoc />
    public partial class _2ChangeIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdRectangle",
                table: "Rectangles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdCoordinate",
                table: "Coordinates",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Rectangles",
                newName: "IdRectangle");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Coordinates",
                newName: "IdCoordinate");
        }
    }
}
