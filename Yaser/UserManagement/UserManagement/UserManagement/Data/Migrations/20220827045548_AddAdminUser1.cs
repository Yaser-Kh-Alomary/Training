using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagement.Data.Migrations
{
    public partial class AddAdminUser1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'3c4e901b-cca2-4eff-9c25-0a92354d4fbe', N'yaseralomari138@yahoo.com', N'YASERALOMARI138@YAHOO.COM', N'yaseralomari138@yahoo.com', N'YASERALOMARI138@YAHOO.COM', 0, N'AQAAAAEAACcQAAAAEH3ljlV0LHV+Emk1X35s92b9m0FXvevNvM+aC9rWwNANkNy9Xnkh1X2Nn8LniH0bdg==', N'OTAG6O7ZTM5FHQOK2BSFKGSVWYP23UNU', N'22f6412d-5158-411e-9d38-d45b1b09145c', NULL, 0, 0, NULL, 1, 0)\r\n");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELET FROME [security].[Uses] WHERE  Id='0a1ff4e2-3c2a-4a23-be35-6c694a5e857c'    ");

        }
    }
}
