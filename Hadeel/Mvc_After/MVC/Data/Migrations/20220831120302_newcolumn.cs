using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC.Data.Migrations
{
    public partial class newcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "L_Name",
                schema: "security",
                table: "Uses",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "F_Name",
                schema: "security",
                table: "Uses",
                newName: "FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "security",
                table: "Uses",
                newName: "L_Name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                schema: "security",
                table: "Uses",
                newName: "F_Name");
        }
    }
}
