using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class V22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PCPartPCStore");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "PCPartPCStore",
                columns: table => new
                {
                    AvailableInStoresID = table.Column<int>(type: "int", nullable: false),
                    PartsInStoreID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCPartPCStore", x => new { x.AvailableInStoresID, x.PartsInStoreID });
                    table.ForeignKey(
                        name: "FK_PCPartPCStore_PCPart_PartsInStoreID",
                        column: x => x.PartsInStoreID,
                        principalTable: "PCPart",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PCPartPCStore_Stores_AvailableInStoresID",
                        column: x => x.AvailableInStoresID,
                        principalTable: "Stores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PCPartPCStore_PartsInStoreID",
                table: "PCPartPCStore",
                column: "PartsInStoreID");
        }
    }
}
