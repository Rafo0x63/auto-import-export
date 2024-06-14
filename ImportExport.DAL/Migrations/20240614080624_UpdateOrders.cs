using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImportExport.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Cars_CarID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CarID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CarID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DealerID",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "CarInfo",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DealerName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarInfo",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DealerName",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "CarID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DealerID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CarID",
                table: "Orders",
                column: "CarID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Cars_CarID",
                table: "Orders",
                column: "CarID",
                principalTable: "Cars",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
