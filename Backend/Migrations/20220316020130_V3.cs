using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PCPart_Stores_PCStoreID",
                table: "PCPart");

            migrationBuilder.DropIndex(
                name: "IX_PCPart_PCStoreID",
                table: "PCPart");

            migrationBuilder.DropColumn(
                name: "PCStoreID",
                table: "PCPart");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PCStoreID",
                table: "PCPart",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PCPart_PCStoreID",
                table: "PCPart",
                column: "PCStoreID");

            migrationBuilder.AddForeignKey(
                name: "FK_PCPart_Stores_PCStoreID",
                table: "PCPart",
                column: "PCStoreID",
                principalTable: "Stores",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
