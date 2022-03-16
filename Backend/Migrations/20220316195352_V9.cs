using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class V9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_UserAccount_BuyerID",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "BuyerID",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_UserAccount_BuyerID",
                table: "Orders",
                column: "BuyerID",
                principalTable: "UserAccount",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_UserAccount_BuyerID",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "BuyerID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_UserAccount_BuyerID",
                table: "Orders",
                column: "BuyerID",
                principalTable: "UserAccount",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
