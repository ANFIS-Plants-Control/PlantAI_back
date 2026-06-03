using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataGroups_MqttClients_ClientId",
                table: "DataGroups");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "SensorsData");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "DataGroups",
                newName: "MqttClientId");

            migrationBuilder.RenameIndex(
                name: "IX_DataGroups_ClientId",
                table: "DataGroups",
                newName: "IX_DataGroups_MqttClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_DataGroups_MqttClients_MqttClientId",
                table: "DataGroups",
                column: "MqttClientId",
                principalTable: "MqttClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataGroups_MqttClients_MqttClientId",
                table: "DataGroups");

            migrationBuilder.RenameColumn(
                name: "MqttClientId",
                table: "DataGroups",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_DataGroups_MqttClientId",
                table: "DataGroups",
                newName: "IX_DataGroups_ClientId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "SensorsData",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_DataGroups_MqttClients_ClientId",
                table: "DataGroups",
                column: "ClientId",
                principalTable: "MqttClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
