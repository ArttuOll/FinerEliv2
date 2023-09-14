using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinerEli.Migrations
{
    /// <inheritdoc />
    public partial class Add_Components : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    EufdNameThsCode = table.Column<string>(type: "TEXT", nullable: false),
                    ComponentUnitName = table.Column<string>(type: "TEXT", nullable: false),
                    ComponentClassName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => new { x.EufdNameThsCode, x.ComponentUnitName, x.ComponentClassName });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Components");
        }
    }
}
