using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinerEli.Migrations
{
    /// <inheritdoc />
    public partial class Add_Component_Class : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComponentClasses",
                columns: table => new
                {
                    EufdNameThsCode = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentClasses", x => new { x.EufdNameThsCode, x.Description });
                    table.ForeignKey(
                        name: "FK_ComponentClasses_EufdNames_EufdNameThsCode",
                        column: x => x.EufdNameThsCode,
                        principalTable: "EufdNames",
                        principalColumn: "ThsCode",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComponentClasses");
        }
    }
}
