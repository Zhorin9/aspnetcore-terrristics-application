using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class ChangedFieldTypeInInputDataTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "TerraristicWindow",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 26, 10, 39, 58, 240, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2020, 4, 22, 20, 19, 1, 878, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "TerraristicWindow",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 26, 10, 39, 58, 238, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2020, 4, 22, 20, 19, 1, 876, DateTimeKind.Local));

            migrationBuilder.AlterColumn<string>(
                name: "ApiKey",
                table: "TerraristicWindow",
                nullable: false,
                defaultValue: "ab9d4394-b3d5-4cff-a753-5af59270de4d",
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "InputSensorData",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 26, 10, 39, 58, 271, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2020, 4, 22, 20, 19, 1, 918, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "TerraristicWindow",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 22, 20, 19, 1, 878, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2020, 4, 26, 10, 39, 58, 240, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "TerraristicWindow",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 22, 20, 19, 1, 876, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2020, 4, 26, 10, 39, 58, 238, DateTimeKind.Local));

            migrationBuilder.AlterColumn<string>(
                name: "ApiKey",
                table: "TerraristicWindow",
                nullable: false,
                oldClrType: typeof(string),
                oldDefaultValue: "ab9d4394-b3d5-4cff-a753-5af59270de4d");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "InputSensorData",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 22, 20, 19, 1, 918, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2020, 4, 26, 10, 39, 58, 271, DateTimeKind.Local));
        }
    }
}
