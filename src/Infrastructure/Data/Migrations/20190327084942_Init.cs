using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SensorKind",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Type = table.Column<byte>(nullable: false)
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "date", nullable: false, defaultValue: new DateTime(2019, 3, 27, 9, 49, 42, 43, DateTimeKind.Local)),
                    ModificationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2019, 3, 27, 9, 49, 42, 43, DateTimeKind.Local)),
                    ApiKey = table.Column<Guid>(nullable: false, defaultValue: new Guid("5d44a131-3e39-41bc-b1a5-b902943ffbe7")),
                    UserId = table.Column<string>(nullable: true)
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    PositionId = table.Column<byte>(nullable: false),
                    SensorKindId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    ParrentWindowId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sensor_TerraristicWindow_ParrentWindowId",
                        column: x => x.ParrentWindowId,
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "date", nullable: false, defaultValue: new DateTime(2019, 3, 27, 9, 49, 42, 23, DateTimeKind.Local)),
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                name: "IX_Sensor_ParrentWindowId",
                table: "Sensor",
                column: "ParrentWindowId");

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
