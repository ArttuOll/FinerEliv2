using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinerEli.Migrations
{
    /// <inheritdoc />
    public partial class Refactor_models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComponentClasses_EufdNames_EufdNameThsCode",
                table: "ComponentClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_ComponentUnits_EufdNames_EufdNameThsCode",
                table: "ComponentUnits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComponentUnits",
                table: "ComponentUnits");

            migrationBuilder.DropIndex(
                name: "IX_ComponentUnits_EufdNameThsCode",
                table: "ComponentUnits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComponentClasses",
                table: "ComponentClasses");

            migrationBuilder.RenameColumn(
                name: "EufdNameThsCode",
                table: "ComponentUnits",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "EufdNameThsCode",
                table: "ComponentClasses",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComponentUnits",
                table: "ComponentUnits",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComponentClasses",
                table: "ComponentClasses",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ComponentUnits",
                table: "ComponentUnits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComponentClasses",
                table: "ComponentClasses");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ComponentUnits",
                newName: "EufdNameThsCode");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ComponentClasses",
                newName: "EufdNameThsCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComponentUnits",
                table: "ComponentUnits",
                column: "Description");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComponentClasses",
                table: "ComponentClasses",
                columns: new[] { "EufdNameThsCode", "Description" });

            migrationBuilder.CreateIndex(
                name: "IX_ComponentUnits_EufdNameThsCode",
                table: "ComponentUnits",
                column: "EufdNameThsCode");

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentClasses_EufdNames_EufdNameThsCode",
                table: "ComponentClasses",
                column: "EufdNameThsCode",
                principalTable: "EufdNames",
                principalColumn: "ThsCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentUnits_EufdNames_EufdNameThsCode",
                table: "ComponentUnits",
                column: "EufdNameThsCode",
                principalTable: "EufdNames",
                principalColumn: "ThsCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
