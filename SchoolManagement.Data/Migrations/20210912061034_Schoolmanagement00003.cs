using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class Schoolmanagement00003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "Master",
                table: "StudentClass",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 9, 12, 6, 10, 32, 65, DateTimeKind.Utc).AddTicks(7484), new DateTime(2021, 9, 12, 6, 10, 32, 65, DateTimeKind.Utc).AddTicks(8149) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 9, 12, 6, 10, 32, 65, DateTimeKind.Utc).AddTicks(9372), new DateTime(2021, 9, 12, 6, 10, 32, 65, DateTimeKind.Utc).AddTicks(9377) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 9, 12, 6, 10, 32, 76, DateTimeKind.Utc).AddTicks(7260), new DateTime(2021, 9, 12, 6, 10, 32, 76, DateTimeKind.Utc).AddTicks(7582) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 9, 12, 6, 10, 32, 76, DateTimeKind.Utc).AddTicks(8791), new DateTime(2021, 9, 12, 6, 10, 32, 76, DateTimeKind.Utc).AddTicks(8793) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "Master",
                table: "StudentClass");

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 9, 12, 3, 52, 42, 402, DateTimeKind.Utc).AddTicks(9177), new DateTime(2021, 9, 12, 3, 52, 42, 402, DateTimeKind.Utc).AddTicks(9854) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 9, 12, 3, 52, 42, 403, DateTimeKind.Utc).AddTicks(1878), new DateTime(2021, 9, 12, 3, 52, 42, 403, DateTimeKind.Utc).AddTicks(1882) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 9, 12, 3, 52, 42, 427, DateTimeKind.Utc).AddTicks(3358), new DateTime(2021, 9, 12, 3, 52, 42, 427, DateTimeKind.Utc).AddTicks(4163) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 9, 12, 3, 52, 42, 427, DateTimeKind.Utc).AddTicks(7427), new DateTime(2021, 9, 12, 3, 52, 42, 427, DateTimeKind.Utc).AddTicks(7432) });
        }
    }
}
