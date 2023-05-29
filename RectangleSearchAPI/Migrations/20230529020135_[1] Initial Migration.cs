using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RectangleSearchAPI.Migrations
{
    /// <inheritdoc />
    public partial class _1InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rectangles",
                columns: table => new
                {
                    IdRectangle = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rectangles", x => x.IdRectangle);
                });

            migrationBuilder.CreateTable(
                name: "Coordinates",
                columns: table => new
                {
                    IdCoordinate = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    X = table.Column<double>(type: "float", nullable: false),
                    Y = table.Column<double>(type: "float", nullable: false),
                    IdRectangle = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinates", x => x.IdCoordinate);
                    table.ForeignKey(
                        name: "FK_Coordinates_Rectangles_IdRectangle",
                        column: x => x.IdRectangle,
                        principalTable: "Rectangles",
                        principalColumn: "IdRectangle",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coordinates_IdRectangle",
                table: "Coordinates",
                column: "IdRectangle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coordinates");

            migrationBuilder.DropTable(
                name: "Rectangles");
        }
    }
}
