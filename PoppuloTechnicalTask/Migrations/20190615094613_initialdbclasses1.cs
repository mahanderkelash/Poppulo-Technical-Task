using Microsoft.EntityFrameworkCore.Migrations;

namespace PoppuloTechnicalTask.Migrations
{
    public partial class initialdbclasses1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_InventoryItems_InventoryItemItemId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_InventoryItemItemId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "InventoryItemItemId",
                table: "Categories");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_CategoryId",
                table: "InventoryItems",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_Categories_CategoryId",
                table: "InventoryItems",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_Categories_CategoryId",
                table: "InventoryItems");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItems_CategoryId",
                table: "InventoryItems");

            migrationBuilder.AddColumn<int>(
                name: "InventoryItemItemId",
                table: "Categories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_InventoryItemItemId",
                table: "Categories",
                column: "InventoryItemItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_InventoryItems_InventoryItemItemId",
                table: "Categories",
                column: "InventoryItemItemId",
                principalTable: "InventoryItems",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
