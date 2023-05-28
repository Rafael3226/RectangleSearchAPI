using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RectangleSearchAPI.Migrations
{
    /// <inheritdoc />
    public partial class Ignoretherectanglerelationshipincoordinates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coordinates_Rectangles_RectangleId",
                table: "Coordinates");

            migrationBuilder.DropIndex(
                name: "IX_Coordinates_RectangleId",
                table: "Coordinates");

            migrationBuilder.DropColumn(
                name: "RectangleId",
                table: "Coordinates");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RectangleId",
                table: "Coordinates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Coordinates_RectangleId",
                table: "Coordinates",
                column: "RectangleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coordinates_Rectangles_RectangleId",
                table: "Coordinates",
                column: "RectangleId",
                principalTable: "Rectangles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
