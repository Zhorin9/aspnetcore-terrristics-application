using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ControlSensor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    SensorBlockId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlSensor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SensorKind",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
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
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ApiKey = table.Column<string>(nullable: false, defaultValue: "0e3e6c34-608c-4995-a829-a3a457890e7b"),
                    UserId = table.Column<string>(nullable: true),
                    IsPublic = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerraristicWindow", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SensorBlock",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    SensorKindId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    ParentWindowId = table.Column<int>(nullable: false),
                    ControlSensorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorBlock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SensorBlock_ControlSensor_ControlSensorId",
                        column: x => x.ControlSensorId,
                        principalTable: "ControlSensor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SensorBlock_TerraristicWindow_ParentWindowId",
                        column: x => x.ParentWindowId,
                        principalTable: "TerraristicWindow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SensorBlock_SensorKind_SensorKindId",
                        column: x => x.SensorKindId,
                        principalTable: "SensorKind",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReadSensor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Value = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2021, 3, 29, 18, 59, 12, 326, DateTimeKind.Local).AddTicks(2685)),
                    SensorBlockId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadSensor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReadSensor_SensorBlock_SensorBlockId",
                        column: x => x.SensorBlockId,
                        principalTable: "SensorBlock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReadSensor_SensorBlockId",
                table: "ReadSensor",
                column: "SensorBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_SensorBlock_ControlSensorId",
                table: "SensorBlock",
                column: "ControlSensorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SensorBlock_ParentWindowId",
                table: "SensorBlock",
                column: "ParentWindowId");

            migrationBuilder.CreateIndex(
                name: "IX_SensorBlock_SensorKindId",
                table: "SensorBlock",
                column: "SensorKindId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReadSensor");

            migrationBuilder.DropTable(
                name: "SensorBlock");

            migrationBuilder.DropTable(
                name: "ControlSensor");

            migrationBuilder.DropTable(
                name: "TerraristicWindow");

            migrationBuilder.DropTable(
                name: "SensorKind");
        }
    }
}
