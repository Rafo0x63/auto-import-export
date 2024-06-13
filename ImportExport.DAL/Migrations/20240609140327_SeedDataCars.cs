using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ImportExport.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataCars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "ID", "DealerID", "Fuel", "FuelConsumption", "Make", "Mileage", "Model", "Power", "PreviousOwners", "Price", "Transmission", "Year" },
                values: new object[,]
                {
                    { 1, 1, "Gasoline", 8.4f, "Nissan", 98000, "S15", 250, 2, 24000, "Manual", new DateOnly(2002, 9, 17) },
                    { 2, 2, "Gasoline", 10.2f, "BMW", 75000, "M3", 425, 1, 45000, "Manual", new DateOnly(2016, 5, 20) },
                    { 3, 3, "Diesel", 6.8f, "Audi", 55000, "A4", 190, 1, 32000, "Automatic", new DateOnly(2018, 11, 10) },
                    { 4, 4, "Gasoline", 9.5f, "Mercedes-Benz", 80000, "E-Class", 320, 2, 38000, "Automatic", new DateOnly(2015, 3, 28) },
                    { 5, 1, "Diesel", 5.7f, "Volkswagen", 65000, "Passat", 150, 1, 25000, "Automatic", new DateOnly(2017, 7, 15) },
                    { 6, 2, "Gasoline", 6.2f, "Ford", 70000, "Focus", 125, 1, 18000, "Manual", new DateOnly(2019, 10, 5) },
                    { 7, 3, "Hybrid", 4.5f, "Toyota", 40000, "Corolla", 120, 1, 22000, "Automatic", new DateOnly(2020, 1, 12) },
                    { 8, 4, "Gasoline", 6.5f, "Honda", 50000, "Civic", 150, 1, 20000, "Manual", new DateOnly(2018, 8, 20) },
                    { 9, 1, "Diesel", 5.8f, "Hyundai", 60000, "i30", 110, 1, 19000, "Manual", new DateOnly(2017, 6, 18) },
                    { 10, 1, "Gasoline", 5.2f, "Renault", 45000, "Clio", 100, 1, 15000, "Manual", new DateOnly(2019, 9, 22) },
                    { 11, 3, "Gasoline", 6.2f, "Renault", 85000, "Megane", 150, 2, 22000, "Manual", new DateOnly(2019, 9, 22) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 11);
        }
    }
}
