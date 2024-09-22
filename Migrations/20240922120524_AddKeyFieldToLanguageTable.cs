using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetCoreRestAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddKeyFieldToLanguageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "Languages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Key",
                table: "Languages");
        }
    }
}
