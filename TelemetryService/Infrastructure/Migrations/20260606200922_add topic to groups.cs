using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addtopictogroups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "DataGroups",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DataGroups_TopicId",
                table: "DataGroups",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_DataGroups_TopicDefinitions_TopicId",
                table: "DataGroups",
                column: "TopicId",
                principalTable: "TopicDefinitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataGroups_TopicDefinitions_TopicId",
                table: "DataGroups");

            migrationBuilder.DropIndex(
                name: "IX_DataGroups_TopicId",
                table: "DataGroups");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "DataGroups");
        }
    }
}
