using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class refactormqtt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MqttClientOptions");

            migrationBuilder.CreateTable(
                name: "BrokerParpameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Host = table.Column<string>(type: "text", nullable: false),
                    Port = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrokerParpameters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TopicDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Topic = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicDefinitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MqttSubscription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientId = table.Column<string>(type: "text", nullable: false),
                    TopicId = table.Column<int>(type: "integer", nullable: false),
                    BrokerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MqttSubscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MqttSubscription_BrokerParpameters_BrokerId",
                        column: x => x.BrokerId,
                        principalTable: "BrokerParpameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MqttSubscription_TopicDefinitions_TopicId",
                        column: x => x.TopicId,
                        principalTable: "TopicDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MqttSubscription_BrokerId",
                table: "MqttSubscription",
                column: "BrokerId");

            migrationBuilder.CreateIndex(
                name: "IX_MqttSubscription_TopicId",
                table: "MqttSubscription",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicDefinitions_Topic",
                table: "TopicDefinitions",
                column: "Topic",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MqttSubscription");

            migrationBuilder.DropTable(
                name: "BrokerParpameters");

            migrationBuilder.DropTable(
                name: "TopicDefinitions");

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
        }
    }
}
