using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class Schoolmanagement00008 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "Lesson",
                table: "Lesson",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 58, 30, 356, DateTimeKind.Utc).AddTicks(4637), new DateTime(2021, 8, 5, 10, 58, 30, 356, DateTimeKind.Utc).AddTicks(4882) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 58, 30, 356, DateTimeKind.Utc).AddTicks(5834), new DateTime(2021, 8, 5, 10, 58, 30, 356, DateTimeKind.Utc).AddTicks(5836) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 58, 30, 366, DateTimeKind.Utc).AddTicks(6081), new DateTime(2021, 8, 5, 10, 58, 30, 366, DateTimeKind.Utc).AddTicks(6383) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 58, 30, 366, DateTimeKind.Utc).AddTicks(7575), new DateTime(2021, 8, 5, 10, 58, 30, 366, DateTimeKind.Utc).AddTicks(7577) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "Lesson",
                table: "Lesson");

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 4, 5, 34, 35, 677, DateTimeKind.Utc).AddTicks(8822), new DateTime(2021, 8, 4, 5, 34, 35, 677, DateTimeKind.Utc).AddTicks(9180) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 4, 5, 34, 35, 678, DateTimeKind.Utc).AddTicks(590), new DateTime(2021, 8, 4, 5, 34, 35, 678, DateTimeKind.Utc).AddTicks(593) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 4, 5, 34, 35, 691, DateTimeKind.Utc).AddTicks(2435), new DateTime(2021, 8, 4, 5, 34, 35, 691, DateTimeKind.Utc).AddTicks(2782) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 4, 5, 34, 35, 691, DateTimeKind.Utc).AddTicks(4146), new DateTime(2021, 8, 4, 5, 34, 35, 691, DateTimeKind.Utc).AddTicks(4148) });
        }
    }
}
