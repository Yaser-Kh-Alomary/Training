using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagement.Data.Migrations
{
    public partial class AddAdmin100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [security].[UserRoles] (UserId, RoleId) SELECT '33dd549a-b9e8-4d74-b260-26d169766cdf', Id FROM[security].[Roles]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM  [security].[UserRoles] WHERE UserId= '33dd549a-b9e8-4d74-b260-26d169766cdf'");
        }
    }
}
