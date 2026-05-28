using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GroupDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MqttClientOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientId = table.Column<string>(type: "text", nullable: false),
                    Host = table.Column<string>(type: "text", nullable: false),
                    Port = table.Column<int>(type: "integer", nullable: false),
                    Topic = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MqttClientOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SensorType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SensorsData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<double>(type: "double precision", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SensorTypeId = table.Column<int>(type: "integer", nullable: false),
                    GroupId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorsData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SensorsData_DataGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "DataGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SensorsData_SensorType_SensorTypeId",
                        column: x => x.SensorTypeId,
                        principalTable: "SensorType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SensorType",
                columns: new[] { "Id", "TypeName" },
                values: new object[,]
                {
                    { 1, "Temperature" },
                    { 2, "Humidity" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SensorsData_GroupId",
                table: "SensorsData",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SensorsData_SensorTypeId",
                table: "SensorsData",
                column: "SensorTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MqttClientOptions");

            migrationBuilder.DropTable(
                name: "SensorsData");

            migrationBuilder.DropTable(
                name: "DataGroups");

            migrationBuilder.DropTable(
                name: "SensorType");
        }
    }
}
