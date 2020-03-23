using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class AddedNewFlagToTerraristicsWindow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "TerraristicWindow",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 23, 19, 21, 38, 62, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2020, 1, 16, 20, 35, 43, 296, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "TerraristicWindow",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 23, 19, 21, 38, 62, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2020, 1, 16, 20, 35, 43, 296, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "ApiKey",
                table: "TerraristicWindow",
                nullable: false,
                defaultValue: new Guid("159e03c4-1354-4d59-8b8f-9db435464081"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("9bec5f6c-6ff0-4bac-8d0d-e60819a5f3b3"));

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "TerraristicWindow",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "InputSensorData",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 23, 19, 21, 38, 50, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2020, 1, 16, 20, 35, 43, 281, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "TerraristicWindow");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "TerraristicWindow",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2020, 1, 16, 20, 35, 43, 296, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2020, 3, 23, 19, 21, 38, 62, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "TerraristicWindow",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2020, 1, 16, 20, 35, 43, 296, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2020, 3, 23, 19, 21, 38, 62, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "ApiKey",
                table: "TerraristicWindow",
                nullable: false,
                defaultValue: new Guid("9bec5f6c-6ff0-4bac-8d0d-e60819a5f3b3"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("159e03c4-1354-4d59-8b8f-9db435464081"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "InputSensorData",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2020, 1, 16, 20, 35, 43, 281, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2020, 3, 23, 19, 21, 38, 50, DateTimeKind.Local));
        }
    }
}
