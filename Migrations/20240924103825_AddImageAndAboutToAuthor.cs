using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetCoreRestAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddImageAndAboutToAuthor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "About",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Authors");
        }
    }
}
