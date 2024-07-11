using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpeditionAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedBackExpeditionIdFieldAndRemovedRobotListFromExpeditionClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Robots_Expeditions_ExpeditionId",
                table: "Robots");

            migrationBuilder.DropIndex(
                name: "IX_Robots_ExpeditionId",
                table: "Robots");

            migrationBuilder.AlterColumn<int>(
                name: "ExpeditionId",
                table: "Robots",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ExpeditionId",
                table: "Robots",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Robots_ExpeditionId",
                table: "Robots",
                column: "ExpeditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Robots_Expeditions_ExpeditionId",
                table: "Robots",
                column: "ExpeditionId",
                principalTable: "Expeditions",
                principalColumn: "Id");
        }
    }
}
