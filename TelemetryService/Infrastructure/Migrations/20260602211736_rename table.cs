using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class renametable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MqttClients_BrokerParpameters_BrokerId",
                table: "MqttClients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BrokerParpameters",
                table: "BrokerParpameters");

            migrationBuilder.RenameTable(
                name: "BrokerParpameters",
                newName: "BrokerParameters");

            migrationBuilder.RenameIndex(
                name: "IX_BrokerParpameters_Host_Port",
                table: "BrokerParameters",
                newName: "IX_BrokerParameters_Host_Port");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "DataGroups",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BrokerParameters",
                table: "BrokerParameters",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DataGroups_ClientId",
                table: "DataGroups",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_DataGroups_MqttClients_ClientId",
                table: "DataGroups",
                column: "ClientId",
                principalTable: "MqttClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MqttClients_BrokerParameters_BrokerId",
                table: "MqttClients",
                column: "BrokerId",
                principalTable: "BrokerParameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataGroups_MqttClients_ClientId",
                table: "DataGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_MqttClients_BrokerParameters_BrokerId",
                table: "MqttClients");

            migrationBuilder.DropIndex(
                name: "IX_DataGroups_ClientId",
                table: "DataGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BrokerParameters",
                table: "BrokerParameters");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "DataGroups");

            migrationBuilder.RenameTable(
                name: "BrokerParameters",
                newName: "BrokerParpameters");

            migrationBuilder.RenameIndex(
                name: "IX_BrokerParameters_Host_Port",
                table: "BrokerParpameters",
                newName: "IX_BrokerParpameters_Host_Port");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BrokerParpameters",
                table: "BrokerParpameters",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MqttClients_BrokerParpameters_BrokerId",
                table: "MqttClients",
                column: "BrokerId",
                principalTable: "BrokerParpameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
