using Microsoft.EntityFrameworkCore.Migrations;

namespace ModellenBureau4.Data.Migrations
{
    public partial class _14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Verified",
                table: "Employees",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Verified",
                table: "Customers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Verified",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Verified",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Verified",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Verified",
                table: "AspNetUsers");
        }
    }
}
