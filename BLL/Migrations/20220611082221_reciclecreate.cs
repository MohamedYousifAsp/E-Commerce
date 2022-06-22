using Microsoft.EntityFrameworkCore.Migrations;

namespace BLL.Migrations
{
    public partial class reciclecreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CatogaryNo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProducrNo",
                table: "ProductImages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CatogaryNo",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProducrNo",
                table: "ProductImages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
