using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PoppuloTechnicalTask.Migrations
{
    public partial class initialDatetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ItemEntryDate",
                table: "InventoryItems",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemEntryDate",
                table: "InventoryItems");
        }
    }
}
