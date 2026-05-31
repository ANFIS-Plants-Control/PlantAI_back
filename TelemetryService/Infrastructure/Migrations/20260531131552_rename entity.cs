using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class renameentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MqttSubscription_BrokerParpameters_BrokerId",
                table: "MqttSubscription");

            migrationBuilder.DropForeignKey(
                name: "FK_MqttSubscription_TopicDefinitions_TopicId",
                table: "MqttSubscription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MqttSubscription",
                table: "MqttSubscription");

            migrationBuilder.RenameTable(
                name: "MqttSubscription",
                newName: "MqttClients");

            migrationBuilder.RenameIndex(
                name: "IX_MqttSubscription_TopicId",
                table: "MqttClients",
                newName: "IX_MqttClients_TopicId");

            migrationBuilder.RenameIndex(
                name: "IX_MqttSubscription_BrokerId",
                table: "MqttClients",
                newName: "IX_MqttClients_BrokerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MqttClients",
                table: "MqttClients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MqttClients_BrokerParpameters_BrokerId",
                table: "MqttClients",
                column: "BrokerId",
                principalTable: "BrokerParpameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MqttClients_TopicDefinitions_TopicId",
                table: "MqttClients",
                column: "TopicId",
                principalTable: "TopicDefinitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MqttClients_BrokerParpameters_BrokerId",
                table: "MqttClients");

            migrationBuilder.DropForeignKey(
                name: "FK_MqttClients_TopicDefinitions_TopicId",
                table: "MqttClients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MqttClients",
                table: "MqttClients");

            migrationBuilder.RenameTable(
                name: "MqttClients",
                newName: "MqttSubscription");

            migrationBuilder.RenameIndex(
                name: "IX_MqttClients_TopicId",
                table: "MqttSubscription",
                newName: "IX_MqttSubscription_TopicId");

            migrationBuilder.RenameIndex(
                name: "IX_MqttClients_BrokerId",
                table: "MqttSubscription",
                newName: "IX_MqttSubscription_BrokerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MqttSubscription",
                table: "MqttSubscription",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MqttSubscription_BrokerParpameters_BrokerId",
                table: "MqttSubscription",
                column: "BrokerId",
                principalTable: "BrokerParpameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MqttSubscription_TopicDefinitions_TopicId",
                table: "MqttSubscription",
                column: "TopicId",
                principalTable: "TopicDefinitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
