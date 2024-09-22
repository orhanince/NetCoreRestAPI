using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetCoreRestAPI.Migrations
{
    /// <inheritdoc />
    public partial class PublisherYearToBooksAndAddAboutFieldToPublisher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "Publishers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PublishedYear",
                table: "Books",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "About",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "PublishedYear",
                table: "Books");
        }
    }
}
