using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class AddedFieldToSensorKind : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "TerraristicWindow",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2020, 1, 16, 20, 35, 43, 296, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2019, 12, 23, 14, 49, 29, 206, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "TerraristicWindow",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2020, 1, 16, 20, 35, 43, 296, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2019, 12, 23, 14, 49, 29, 206, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "ApiKey",
                table: "TerraristicWindow",
                nullable: false,
                defaultValue: new Guid("9bec5f6c-6ff0-4bac-8d0d-e60819a5f3b3"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("4f28f461-4427-438e-834d-33cc59eddadf"));

            migrationBuilder.AddColumn<int>(
                name: "OutputType",
                table: "SensorKind",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "InputSensorData",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2020, 1, 16, 20, 35, 43, 281, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2019, 12, 23, 14, 49, 29, 191, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OutputType",
                table: "SensorKind");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "TerraristicWindow",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2019, 12, 23, 14, 49, 29, 206, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2020, 1, 16, 20, 35, 43, 296, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "TerraristicWindow",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2019, 12, 23, 14, 49, 29, 206, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2020, 1, 16, 20, 35, 43, 296, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "ApiKey",
                table: "TerraristicWindow",
                nullable: false,
                defaultValue: new Guid("4f28f461-4427-438e-834d-33cc59eddadf"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("9bec5f6c-6ff0-4bac-8d0d-e60819a5f3b3"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "InputSensorData",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2019, 12, 23, 14, 49, 29, 191, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2020, 1, 16, 20, 35, 43, 281, DateTimeKind.Local));
        }
    }
}
