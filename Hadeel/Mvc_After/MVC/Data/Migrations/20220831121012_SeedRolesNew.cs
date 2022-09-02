using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MVC.Data.Migrations
{
    public partial class SeedRolesNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
              table: "Roles",
              columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp", },
              values: new object[] { Guid.NewGuid().ToString(), "SuperAdmin", "SuperAdmin".ToUpper(), Guid.NewGuid().ToString() },
              schema: "security"

               );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELET FROM [security].[Roles]");
        }
    }
}
