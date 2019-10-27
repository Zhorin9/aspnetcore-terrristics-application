﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class AddedShortDecriptionToSensorKind : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "TerraristicWindow",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2019, 10, 27, 12, 8, 21, 69, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2019, 10, 21, 19, 31, 43, 766, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "TerraristicWindow",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2019, 10, 27, 12, 8, 21, 68, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2019, 10, 21, 19, 31, 43, 765, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "ApiKey",
                table: "TerraristicWindow",
                nullable: false,
                defaultValue: new Guid("8a04a29e-f55a-4730-bd3e-05f7424200f9"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("44313a74-d595-4bf5-aeed-fd3528930e6a"));

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "SensorKind",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "InputSensorData",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2019, 10, 27, 12, 8, 21, 49, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2019, 10, 21, 19, 31, 43, 753, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "SensorKind");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "TerraristicWindow",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2019, 10, 21, 19, 31, 43, 766, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2019, 10, 27, 12, 8, 21, 69, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "TerraristicWindow",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2019, 10, 21, 19, 31, 43, 765, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2019, 10, 27, 12, 8, 21, 68, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "ApiKey",
                table: "TerraristicWindow",
                nullable: false,
                defaultValue: new Guid("44313a74-d595-4bf5-aeed-fd3528930e6a"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("8a04a29e-f55a-4730-bd3e-05f7424200f9"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "InputSensorData",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2019, 10, 21, 19, 31, 43, 753, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2019, 10, 27, 12, 8, 21, 49, DateTimeKind.Local));
        }
    }
}
