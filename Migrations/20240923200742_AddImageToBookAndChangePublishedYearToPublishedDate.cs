using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetCoreRestAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddImageToBookAndChangePublishedYearToPublishedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublishedYear",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishedDate",
                table: "Books",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "PublishedDate",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "PublishedYear",
                table: "Books",
                type: "int",
                nullable: true);
        }
    }
}
