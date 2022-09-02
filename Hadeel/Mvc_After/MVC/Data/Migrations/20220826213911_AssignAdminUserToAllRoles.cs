using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC.Data.Migrations
{
    public partial class AssignAdminUserToAllRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [security].[UserRoles] (UserId, RoleId) SELECT '9fc5e1a7-d9e7-4f32-95fc-66f5d5300167', Id FROM[security].[Roles]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM  [security].[UserRoles] WHERE UserId= '9fc5e1a7-d9e7-4f32-95fc-66f5d5300167'");
        }
    }
}
