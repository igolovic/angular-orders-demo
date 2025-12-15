using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrdersDemo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Max Mustermann" },
                    { 2, "Erika Musterfrau" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Tisch" },
                    { 2, "Stuhl" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ClientId", "CreatedAt", "ModifiedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 11, 30, 15, 15, 26, 521, DateTimeKind.Utc).AddTicks(5803), null },
                    { 2, 2, new DateTime(2025, 11, 30, 15, 15, 26, 521, DateTimeKind.Utc).AddTicks(5805), null }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 2 },
                    { 2, 1, 2, 4 },
                    { 3, 2, 2, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
