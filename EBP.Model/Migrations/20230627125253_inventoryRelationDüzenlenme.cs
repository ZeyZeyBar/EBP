using Microsoft.EntityFrameworkCore.Migrations;

namespace EBP.Model.Migrations
{
    public partial class inventoryRelationDüzenlenme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Brands_BrandID",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Departments_DepartmentID",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_BrandID",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_DepartmentID",
                table: "Inventory");

            migrationBuilder.AddColumn<int>(
                name: "InventoryID",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InventoryID",
                table: "Brands",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_InventoryID",
                table: "Departments",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_InventoryID",
                table: "Brands",
                column: "InventoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Inventory_InventoryID",
                table: "Brands",
                column: "InventoryID",
                principalTable: "Inventory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Inventory_InventoryID",
                table: "Departments",
                column: "InventoryID",
                principalTable: "Inventory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Inventory_InventoryID",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Inventory_InventoryID",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_InventoryID",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Brands_InventoryID",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "InventoryID",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "InventoryID",
                table: "Brands");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_BrandID",
                table: "Inventory",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_DepartmentID",
                table: "Inventory",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Brands_BrandID",
                table: "Inventory",
                column: "BrandID",
                principalTable: "Brands",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Departments_DepartmentID",
                table: "Inventory",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
