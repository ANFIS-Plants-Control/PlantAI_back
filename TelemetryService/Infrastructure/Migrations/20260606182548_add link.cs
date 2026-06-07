using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addlink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MqttClients_TopicDefinitions_TopicId",
                table: "MqttClients");

            migrationBuilder.DropIndex(
                name: "IX_MqttClients_TopicId",
                table: "MqttClients");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "MqttClients");

            migrationBuilder.CreateTable(
                name: "MqttClientTopicDefinition",
                columns: table => new
                {
                    SubscriptionsId = table.Column<int>(type: "integer", nullable: false),
                    TopicsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MqttClientTopicDefinition", x => new { x.SubscriptionsId, x.TopicsId });
                    table.ForeignKey(
                        name: "FK_MqttClientTopicDefinition_MqttClients_SubscriptionsId",
                        column: x => x.SubscriptionsId,
                        principalTable: "MqttClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MqttClientTopicDefinition_TopicDefinitions_TopicsId",
                        column: x => x.TopicsId,
                        principalTable: "TopicDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MqttClientTopicDefinition_TopicsId",
                table: "MqttClientTopicDefinition",
                column: "TopicsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MqttClientTopicDefinition");

            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "MqttClients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MqttClients_TopicId",
                table: "MqttClients",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_MqttClients_TopicDefinitions_TopicId",
                table: "MqttClients",
                column: "TopicId",
                principalTable: "TopicDefinitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
