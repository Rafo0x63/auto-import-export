using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImportExport.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Dealers_DealerID",
                table: "Cars");

            migrationBuilder.AlterColumn<string>(
                name: "Year",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<int>(
                name: "DealerID",
                table: "Cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 1,
                column: "Year",
                value: "2002");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 2,
                column: "Year",
                value: "2016");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 3,
                column: "Year",
                value: "2018");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 4,
                column: "Year",
                value: "2015");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 5,
                column: "Year",
                value: "2017");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 6,
                column: "Year",
                value: "2019");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 7,
                column: "Year",
                value: "2020");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 8,
                column: "Year",
                value: "2018");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 9,
                column: "Year",
                value: "2017");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 10,
                column: "Year",
                value: "2019");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 11,
                column: "Year",
                value: "2019");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Dealers_DealerID",
                table: "Cars",
                column: "DealerID",
                principalTable: "Dealers",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Dealers_DealerID",
                table: "Cars");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Year",
                table: "Cars",
                type: "date",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "DealerID",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 1,
                column: "Year",
                value: new DateOnly(2002, 9, 17));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 2,
                column: "Year",
                value: new DateOnly(2016, 5, 20));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 3,
                column: "Year",
                value: new DateOnly(2018, 11, 10));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 4,
                column: "Year",
                value: new DateOnly(2015, 3, 28));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 5,
                column: "Year",
                value: new DateOnly(2017, 7, 15));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 6,
                column: "Year",
                value: new DateOnly(2019, 10, 5));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 7,
                column: "Year",
                value: new DateOnly(2020, 1, 12));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 8,
                column: "Year",
                value: new DateOnly(2018, 8, 20));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 9,
                column: "Year",
                value: new DateOnly(2017, 6, 18));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 10,
                column: "Year",
                value: new DateOnly(2019, 9, 22));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 11,
                column: "Year",
                value: new DateOnly(2019, 9, 22));

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Dealers_DealerID",
                table: "Cars",
                column: "DealerID",
                principalTable: "Dealers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
