using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Master.Data.Migrations
{
    public partial class SchoolMaster00001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "School",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolDomain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConnectionString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SMTPServer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SMTPUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SMTPPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SMTPFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SMTPPort = table.Column<int>(type: "int", nullable: false),
                    IsSMTPUseSSL = table.Column<bool>(type: "bit", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("0dc93fdc-9737-41c4-9317-fdfdadfe0f5a")),
                    APIKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("ad77508e-c81b-4714-b55c-17b588876be8")),
                    SecretKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("73d19e3e-a92c-47cc-8f04-049247b42a67")),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "School");
        }
    }
}
