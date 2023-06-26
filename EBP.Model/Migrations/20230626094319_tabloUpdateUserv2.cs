using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EBP.Model.Migrations
{
    public partial class tabloUpdateUserv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Rols_RolID",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Rols");

            migrationBuilder.DropIndex(
                name: "IX_Users_RolID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RolID",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "UserLastName");

            migrationBuilder.AddColumn<string>(
                name: "RolType",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RolType",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserLastName",
                table: "Users",
                newName: "Password");

            migrationBuilder.AddColumn<int>(
                name: "RolID",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Rols",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RolName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rols", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RolID",
                table: "Users",
                column: "RolID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Rols_RolID",
                table: "Users",
                column: "RolID",
                principalTable: "Rols",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
