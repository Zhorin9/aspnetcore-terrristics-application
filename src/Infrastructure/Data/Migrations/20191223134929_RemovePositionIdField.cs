using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class RemovePositionIdField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Sensor");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "TerraristicWindow",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2019, 12, 23, 14, 49, 29, 206, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2019, 10, 27, 12, 8, 21, 69, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "TerraristicWindow",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2019, 12, 23, 14, 49, 29, 206, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2019, 10, 27, 12, 8, 21, 68, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "ApiKey",
                table: "TerraristicWindow",
                nullable: false,
                defaultValue: new Guid("4f28f461-4427-438e-834d-33cc59eddadf"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("8a04a29e-f55a-4730-bd3e-05f7424200f9"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "InputSensorData",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2019, 12, 23, 14, 49, 29, 191, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2019, 10, 27, 12, 8, 21, 49, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "TerraristicWindow",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2019, 10, 27, 12, 8, 21, 69, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2019, 12, 23, 14, 49, 29, 206, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "TerraristicWindow",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2019, 10, 27, 12, 8, 21, 68, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2019, 12, 23, 14, 49, 29, 206, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "ApiKey",
                table: "TerraristicWindow",
                nullable: false,
                defaultValue: new Guid("8a04a29e-f55a-4730-bd3e-05f7424200f9"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("4f28f461-4427-438e-834d-33cc59eddadf"));

            migrationBuilder.AddColumn<byte>(
                name: "PositionId",
                table: "Sensor",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "InputSensorData",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2019, 10, 27, 12, 8, 21, 49, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2019, 12, 23, 14, 49, 29, 191, DateTimeKind.Local));
        }
    }
}
