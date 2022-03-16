using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class V5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PCPartPCStore",
                columns: table => new
                {
                    InStoresID = table.Column<int>(type: "int", nullable: false),
                    PartsAvailableID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCPartPCStore", x => new { x.InStoresID, x.PartsAvailableID });
                    table.ForeignKey(
                        name: "FK_PCPartPCStore_PCPart_PartsAvailableID",
                        column: x => x.PartsAvailableID,
                        principalTable: "PCPart",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PCPartPCStore_Stores_InStoresID",
                        column: x => x.InStoresID,
                        principalTable: "Stores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PCPartPCStore_PartsAvailableID",
                table: "PCPartPCStore",
                column: "PartsAvailableID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PCPartPCStore");
        }
    }
}
