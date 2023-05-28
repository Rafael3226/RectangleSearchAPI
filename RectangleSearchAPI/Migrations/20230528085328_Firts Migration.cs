using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RectangleSearchAPI.Migrations
{
    /// <inheritdoc />
    public partial class FirtsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coordinates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    X = table.Column<double>(type: "float", nullable: false),
                    Y = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rectangles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TopLeftId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BottomRightId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TopLeftCoordinateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rectangles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rectangles_Coordinates_BottomRightId",
                        column: x => x.BottomRightId,
                        principalTable: "Coordinates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rectangles_Coordinates_TopLeftCoordinateId",
                        column: x => x.TopLeftCoordinateId,
                        principalTable: "Coordinates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rectangles_BottomRightId",
                table: "Rectangles",
                column: "BottomRightId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rectangles_TopLeftCoordinateId",
                table: "Rectangles",
                column: "TopLeftCoordinateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rectangles");

            migrationBuilder.DropTable(
                name: "Coordinates");
        }
    }
}
