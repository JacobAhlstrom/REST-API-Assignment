using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DagnysBakeryAPI.Migrations
{
    /// <inheritdoc />
    public partial class OnModelCreating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierId", "Address", "ContactPerson", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Mjölgatan 1", "Jacob Ahlström", "jacobsmjöl@gmail.com", "Jacobs Mjöl AB", "0761123456" },
                    { 2, "Mjölgatan 2", "Fabian Ahlström", "fabiansmjöl@gmail.com", "Fabians Mjöl AB", "0761123457" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ArticleNumber", "Name", "PricePerKg", "SupplierId" },
                values: new object[,]
                {
                    { 1, "A001", "Mjöl", 10.5m, 1 },
                    { 2, "A001", "Mjöl", 9.5m, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 2);
        }
    }
}
