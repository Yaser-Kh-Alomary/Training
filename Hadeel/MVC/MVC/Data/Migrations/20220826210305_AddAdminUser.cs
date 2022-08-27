using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC.Data.Migrations
{
    public partial class AddAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [security].[Uses] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [F_Name], [L_Name], [profile_Pic]) VALUES (N'9fc5e1a7-d9e7-4f32-95fc-66f5d5300167', N'Admin', N'ADMIN', N'Admin@gmail.com', N'ADMIN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEG/M47lXeZ7XvTHIDDg11fmSASisxffyTjWrqY+Xm0ohYLDPeYux678RG0yqvvZxWA==', N'TA3FVKR4ATLZSAFB3M2CAEDG2TP5SYUR', N'f9506995-1417-4425-8222-46543152250a', NULL, 0, 0, NULL, 1, 0, N'Mohammad', N'Sayel ', NULL )");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELET FROME [security].[Uses] WHERE  Id='9fc5e1a7-d9e7-4f32-95fc-66f5d5300167'    ");
        }
    }
}
