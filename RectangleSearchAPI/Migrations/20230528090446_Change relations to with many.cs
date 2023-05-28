using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RectangleSearchAPI.Migrations
{
    /// <inheritdoc />
    public partial class Changerelationstowithmany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rectangles_Coordinates_TopLeftCoordinateId",
                table: "Rectangles");

            migrationBuilder.DropIndex(
                name: "IX_Rectangles_BottomRightId",
                table: "Rectangles");

            migrationBuilder.DropIndex(
                name: "IX_Rectangles_TopLeftCoordinateId",
                table: "Rectangles");

            migrationBuilder.DropColumn(
                name: "TopLeftCoordinateId",
                table: "Rectangles");

            migrationBuilder.AddColumn<Guid>(
                name: "RectangleId",
                table: "Coordinates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Rectangles_BottomRightId",
                table: "Rectangles",
                column: "BottomRightId");

            migrationBuilder.CreateIndex(
                name: "IX_Rectangles_TopLeftId",
                table: "Rectangles",
                column: "TopLeftId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Rectangles_Coordinates_TopLeftId",
                table: "Rectangles",
                column: "TopLeftId",
                principalTable: "Coordinates",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coordinates_Rectangles_RectangleId",
                table: "Coordinates");

            migrationBuilder.DropForeignKey(
                name: "FK_Rectangles_Coordinates_TopLeftId",
                table: "Rectangles");

            migrationBuilder.DropIndex(
                name: "IX_Rectangles_BottomRightId",
                table: "Rectangles");

            migrationBuilder.DropIndex(
                name: "IX_Rectangles_TopLeftId",
                table: "Rectangles");

            migrationBuilder.DropIndex(
                name: "IX_Coordinates_RectangleId",
                table: "Coordinates");

            migrationBuilder.DropColumn(
                name: "RectangleId",
                table: "Coordinates");

            migrationBuilder.AddColumn<Guid>(
                name: "TopLeftCoordinateId",
                table: "Rectangles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Rectangles_BottomRightId",
                table: "Rectangles",
                column: "BottomRightId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rectangles_TopLeftCoordinateId",
                table: "Rectangles",
                column: "TopLeftCoordinateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rectangles_Coordinates_TopLeftCoordinateId",
                table: "Rectangles",
                column: "TopLeftCoordinateId",
                principalTable: "Coordinates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
