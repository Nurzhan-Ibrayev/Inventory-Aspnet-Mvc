using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItransitionProjectMVC.Migrations
{
    /// <inheritdoc />
    public partial class AnotherFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "xmin",
                table: "Inventories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "xmin",
                table: "Inventories",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
