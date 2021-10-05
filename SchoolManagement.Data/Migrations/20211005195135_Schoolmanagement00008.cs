using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class Schoolmanagement00008 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProfileImage",
                schema: "Account",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ProfileImage", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 10, 5, 19, 51, 32, 260, DateTimeKind.Utc).AddTicks(7289), null, new DateTime(2021, 10, 5, 19, 51, 32, 260, DateTimeKind.Utc).AddTicks(7555) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ProfileImage", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 10, 5, 19, 51, 32, 260, DateTimeKind.Utc).AddTicks(8330), null, new DateTime(2021, 10, 5, 19, 51, 32, 260, DateTimeKind.Utc).AddTicks(8332) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 10, 5, 19, 51, 32, 272, DateTimeKind.Utc).AddTicks(637), new DateTime(2021, 10, 5, 19, 51, 32, 272, DateTimeKind.Utc).AddTicks(985) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 10, 5, 19, 51, 32, 272, DateTimeKind.Utc).AddTicks(2338), new DateTime(2021, 10, 5, 19, 51, 32, 272, DateTimeKind.Utc).AddTicks(2340) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "ProfileImage",
                schema: "Account",
                table: "User",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ProfileImage", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 10, 3, 22, 5, 30, 507, DateTimeKind.Utc).AddTicks(6327), (byte)0, new DateTime(2021, 10, 3, 22, 5, 30, 507, DateTimeKind.Utc).AddTicks(6560) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ProfileImage", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 10, 3, 22, 5, 30, 507, DateTimeKind.Utc).AddTicks(7200), (byte)0, new DateTime(2021, 10, 3, 22, 5, 30, 507, DateTimeKind.Utc).AddTicks(7201) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 10, 3, 22, 5, 30, 518, DateTimeKind.Utc).AddTicks(4365), new DateTime(2021, 10, 3, 22, 5, 30, 518, DateTimeKind.Utc).AddTicks(4771) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 10, 3, 22, 5, 30, 518, DateTimeKind.Utc).AddTicks(6077), new DateTime(2021, 10, 3, 22, 5, 30, 518, DateTimeKind.Utc).AddTicks(6079) });
        }
    }
}
