using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinerEli.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EufdNames",
                columns: table => new
                {
                    ThsCode = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EufdNames", x => x.ThsCode);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComponentUnits",
                columns: table => new
                {
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    EufdNameThsCode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentUnits", x => x.Description);
                    table.ForeignKey(
                        name: "FK_ComponentUnits_EufdNames_EufdNameThsCode",
                        column: x => x.EufdNameThsCode,
                        principalTable: "EufdNames",
                        principalColumn: "ThsCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComponentValues",
                columns: table => new
                {
                    FoodId = table.Column<int>(type: "INTEGER", nullable: false),
                    EufdNameThsCode = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentValues", x => new { x.FoodId, x.EufdNameThsCode });
                    table.ForeignKey(
                        name: "FK_ComponentValues_EufdNames_EufdNameThsCode",
                        column: x => x.EufdNameThsCode,
                        principalTable: "EufdNames",
                        principalColumn: "ThsCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComponentValues_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComponentUnits_EufdNameThsCode",
                table: "ComponentUnits",
                column: "EufdNameThsCode");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentValues_EufdNameThsCode",
                table: "ComponentValues",
                column: "EufdNameThsCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComponentUnits");

            migrationBuilder.DropTable(
                name: "ComponentValues");

            migrationBuilder.DropTable(
                name: "EufdNames");

            migrationBuilder.DropTable(
                name: "Foods");
        }
    }
}
