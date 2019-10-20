using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class FixedFieldNamesAddedDescriptionToWindow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sensor_TerraristicWindow_ParrentWindowId",
                table: "Sensor");

            migrationBuilder.RenameColumn(
                name: "ParrentWindowId",
                table: "Sensor",
                newName: "ParentWindowId");

            migrationBuilder.RenameIndex(
                name: "IX_Sensor_ParrentWindowId",
                table: "Sensor",
                newName: "IX_Sensor_ParentWindowId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "TerraristicWindow",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2019, 10, 20, 21, 43, 15, 460, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2019, 3, 27, 9, 49, 42, 43, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "TerraristicWindow",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2019, 10, 20, 21, 43, 15, 459, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2019, 3, 27, 9, 49, 42, 43, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "ApiKey",
                table: "TerraristicWindow",
                nullable: false,
                defaultValue: new Guid("2592cdf6-cd1d-42ae-b9a3-a96741559cf0"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("5d44a131-3e39-41bc-b1a5-b902943ffbe7"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TerraristicWindow",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "InputSensorData",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2019, 10, 20, 21, 43, 15, 447, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2019, 3, 27, 9, 49, 42, 23, DateTimeKind.Local));

            migrationBuilder.AddForeignKey(
                name: "FK_Sensor_TerraristicWindow_ParentWindowId",
                table: "Sensor",
                column: "ParentWindowId",
                principalTable: "TerraristicWindow",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sensor_TerraristicWindow_ParentWindowId",
                table: "Sensor");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "TerraristicWindow");

            migrationBuilder.RenameColumn(
                name: "ParentWindowId",
                table: "Sensor",
                newName: "ParrentWindowId");

            migrationBuilder.RenameIndex(
                name: "IX_Sensor_ParentWindowId",
                table: "Sensor",
                newName: "IX_Sensor_ParrentWindowId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "TerraristicWindow",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2019, 3, 27, 9, 49, 42, 43, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2019, 10, 20, 21, 43, 15, 460, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "TerraristicWindow",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2019, 3, 27, 9, 49, 42, 43, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2019, 10, 20, 21, 43, 15, 459, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "ApiKey",
                table: "TerraristicWindow",
                nullable: false,
                defaultValue: new Guid("5d44a131-3e39-41bc-b1a5-b902943ffbe7"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("2592cdf6-cd1d-42ae-b9a3-a96741559cf0"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "InputSensorData",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2019, 3, 27, 9, 49, 42, 23, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2019, 10, 20, 21, 43, 15, 447, DateTimeKind.Local));

            migrationBuilder.AddForeignKey(
                name: "FK_Sensor_TerraristicWindow_ParrentWindowId",
                table: "Sensor",
                column: "ParrentWindowId",
                principalTable: "TerraristicWindow",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
