using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetCoreRestAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddNumberOfPagesToBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfPages",
                table: "Books",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfPages",
                table: "Books");
        }
    }
}
