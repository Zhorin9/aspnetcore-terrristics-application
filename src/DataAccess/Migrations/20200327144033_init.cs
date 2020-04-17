using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SensorKind",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    ShortDescription = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    OutputType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorKind", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TerraristicWindow",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(type: "date", nullable: false, defaultValue: new DateTime(2020, 3, 27, 15, 40, 33, 530, DateTimeKind.Local)),
                    ModificationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2020, 3, 27, 15, 40, 33, 532, DateTimeKind.Local)),
                    ApiKey = table.Column<string>(nullable: false, defaultValue: "8845851c-4f90-4e45-b389-c371b1a2cf3e"),
                    UserId = table.Column<string>(nullable: true),
                    IsPublic = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerraristicWindow", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sensor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    SensorKindId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    ParentWindowId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sensor_TerraristicWindow_ParentWindowId",
                        column: x => x.ParentWindowId,
                        principalTable: "TerraristicWindow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sensor_SensorKind_SensorKindId",
                        column: x => x.SensorKindId,
                        principalTable: "SensorKind",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InputSensorData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Value = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "date", nullable: false, defaultValue: new DateTime(2020, 3, 27, 15, 40, 33, 542, DateTimeKind.Local)),
                    SensorBlockId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputSensorData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InputSensorData_Sensor_SensorBlockId",
                        column: x => x.SensorBlockId,
                        principalTable: "Sensor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OutputSensorData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    State = table.Column<byte>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    SensorBlockId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutputSensorData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutputSensorData_Sensor_SensorBlockId",
                        column: x => x.SensorBlockId,
                        principalTable: "Sensor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InputSensorData_SensorBlockId",
                table: "InputSensorData",
                column: "SensorBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_OutputSensorData_SensorBlockId",
                table: "OutputSensorData",
                column: "SensorBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_Sensor_ParentWindowId",
                table: "Sensor",
                column: "ParentWindowId");

            migrationBuilder.CreateIndex(
                name: "IX_Sensor_SensorKindId",
                table: "Sensor",
                column: "SensorKindId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InputSensorData");

            migrationBuilder.DropTable(
                name: "OutputSensorData");

            migrationBuilder.DropTable(
                name: "Sensor");

            migrationBuilder.DropTable(
                name: "TerraristicWindow");

            migrationBuilder.DropTable(
                name: "SensorKind");
        }
    }
}
