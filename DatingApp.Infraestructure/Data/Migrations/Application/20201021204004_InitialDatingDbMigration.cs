using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.Infrastructure.Data.Migrations.Application
{
    public partial class InitialDatingDbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Dating.Authentication");

            migrationBuilder.CreateTable(
                name: "AppUsers",
                schema: "Dating.Authentication",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUsers",
                schema: "Dating.Authentication");
        }
    }
}
