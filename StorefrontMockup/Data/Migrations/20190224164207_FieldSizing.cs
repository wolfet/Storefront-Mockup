using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StorefrontMockup.Migrations
{
    public partial class FieldSizing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItem_UnitOfMeasure_UnitOfMeasureId",
                table: "InventoryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItemPhoto_InventoryItem_InventoryItemId",
                table: "InventoryItemPhoto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitOfMeasure",
                table: "UnitOfMeasure");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryItemPhoto",
                table: "InventoryItemPhoto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryItem",
                table: "InventoryItem");

            migrationBuilder.RenameTable(
                name: "UnitOfMeasure",
                newName: "UnitsOfMeasure");

            migrationBuilder.RenameTable(
                name: "InventoryItemPhoto",
                newName: "InventoryItemPhotos");

            migrationBuilder.RenameTable(
                name: "InventoryItem",
                newName: "InventoryItems");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryItemPhoto_InventoryItemId",
                table: "InventoryItemPhotos",
                newName: "IX_InventoryItemPhotos_InventoryItemId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryItem_UnitOfMeasureId",
                table: "InventoryItems",
                newName: "IX_InventoryItems_UnitOfMeasureId");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "InventoryItemPhotos",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Caption",
                table: "InventoryItemPhotos",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "InventoryItems",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitsOfMeasure",
                table: "UnitsOfMeasure",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryItemPhotos",
                table: "InventoryItemPhotos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryItems",
                table: "InventoryItems",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "InventoryItemCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItemCategories", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItemPhotos_InventoryItems_InventoryItemId",
                table: "InventoryItemPhotos",
                column: "InventoryItemId",
                principalTable: "InventoryItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_UnitsOfMeasure_UnitOfMeasureId",
                table: "InventoryItems",
                column: "UnitOfMeasureId",
                principalTable: "UnitsOfMeasure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItemPhotos_InventoryItems_InventoryItemId",
                table: "InventoryItemPhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_UnitsOfMeasure_UnitOfMeasureId",
                table: "InventoryItems");

            migrationBuilder.DropTable(
                name: "InventoryItemCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitsOfMeasure",
                table: "UnitsOfMeasure");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryItems",
                table: "InventoryItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryItemPhotos",
                table: "InventoryItemPhotos");

            migrationBuilder.RenameTable(
                name: "UnitsOfMeasure",
                newName: "UnitOfMeasure");

            migrationBuilder.RenameTable(
                name: "InventoryItems",
                newName: "InventoryItem");

            migrationBuilder.RenameTable(
                name: "InventoryItemPhotos",
                newName: "InventoryItemPhoto");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryItems_UnitOfMeasureId",
                table: "InventoryItem",
                newName: "IX_InventoryItem_UnitOfMeasureId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryItemPhotos_InventoryItemId",
                table: "InventoryItemPhoto",
                newName: "IX_InventoryItemPhoto_InventoryItemId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "InventoryItem",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "InventoryItemPhoto",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Caption",
                table: "InventoryItemPhoto",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitOfMeasure",
                table: "UnitOfMeasure",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryItem",
                table: "InventoryItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryItemPhoto",
                table: "InventoryItemPhoto",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItem_UnitOfMeasure_UnitOfMeasureId",
                table: "InventoryItem",
                column: "UnitOfMeasureId",
                principalTable: "UnitOfMeasure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItemPhoto_InventoryItem_InventoryItemId",
                table: "InventoryItemPhoto",
                column: "InventoryItemId",
                principalTable: "InventoryItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
