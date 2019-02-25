using Microsoft.EntityFrameworkCore.Migrations;

namespace StorefrontMockup.Migrations
{
    public partial class FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InventoryItemCategoryId",
                table: "InventoryItems",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "InventoryItemCategories",
                maxLength: 4000,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_InventoryItemCategoryId",
                table: "InventoryItems",
                column: "InventoryItemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_PrimaryPhotoId",
                table: "InventoryItems",
                column: "PrimaryPhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_InventoryItemCategories_InventoryItemCategoryId",
                table: "InventoryItems",
                column: "InventoryItemCategoryId",
                principalTable: "InventoryItemCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_InventoryItemPhotos_PrimaryPhotoId",
                table: "InventoryItems",
                column: "PrimaryPhotoId",
                principalTable: "InventoryItemPhotos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_InventoryItemCategories_InventoryItemCategoryId",
                table: "InventoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_InventoryItemPhotos_PrimaryPhotoId",
                table: "InventoryItems");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItems_InventoryItemCategoryId",
                table: "InventoryItems");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItems_PrimaryPhotoId",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "InventoryItemCategoryId",
                table: "InventoryItems");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "InventoryItemCategories",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 4000,
                oldNullable: true);
        }
    }
}
