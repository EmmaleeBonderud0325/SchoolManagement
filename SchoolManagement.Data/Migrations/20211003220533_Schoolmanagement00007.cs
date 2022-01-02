using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class Schoolmanagement00007 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Lesson",
                table: "TopicContent",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 10, 3, 22, 5, 30, 507, DateTimeKind.Utc).AddTicks(6327), new DateTime(2021, 10, 3, 22, 5, 30, 507, DateTimeKind.Utc).AddTicks(6560) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 10, 3, 22, 5, 30, 507, DateTimeKind.Utc).AddTicks(7200), new DateTime(2021, 10, 3, 22, 5, 30, 507, DateTimeKind.Utc).AddTicks(7201) });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Lesson",
                table: "TopicContent");

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 10, 2, 12, 1, 6, 130, DateTimeKind.Utc).AddTicks(9524), new DateTime(2021, 10, 2, 12, 1, 6, 131, DateTimeKind.Utc).AddTicks(183) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 10, 2, 12, 1, 6, 131, DateTimeKind.Utc).AddTicks(2195), new DateTime(2021, 10, 2, 12, 1, 6, 131, DateTimeKind.Utc).AddTicks(2200) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 10, 2, 12, 1, 6, 158, DateTimeKind.Utc).AddTicks(994), new DateTime(2021, 10, 2, 12, 1, 6, 158, DateTimeKind.Utc).AddTicks(1828) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 10, 2, 12, 1, 6, 158, DateTimeKind.Utc).AddTicks(5653), new DateTime(2021, 10, 2, 12, 1, 6, 158, DateTimeKind.Utc).AddTicks(5658) });
        }
    }
}
