using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModellenBureau4.Data.Migrations
{
    public partial class _8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BirthDate", "City", "CountryId", "Discriminator", "Email", "FirstName", "Gender", "LastName", "PhoneNumber", "Street", "Zip" },
                values: new object[] { 2, new DateTime(1972, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brussels2", 1, "Customer", "bethany@bethanyspieshop2.com", "Bethany2", 1, "Smith2", "324777888772", "Grote Markt 12", "1002" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
