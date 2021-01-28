using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GroceriesDelivery.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustID = table.Column<string>(type: "TEXT", nullable: false),
                    CustPassword = table.Column<string>(type: "TEXT", nullable: false),
                    CustName = table.Column<string>(type: "TEXT", nullable: false),
                    CustAddress = table.Column<string>(type: "TEXT", nullable: false),
                    CustEmail = table.Column<string>(type: "TEXT", nullable: false),
                    CustPhone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustID);
                });

            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    DriverID = table.Column<string>(type: "TEXT", nullable: false),
                    DriverPassword = table.Column<string>(type: "TEXT", nullable: false),
                    DriverName = table.Column<string>(type: "TEXT", nullable: false),
                    DriverPhone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.DriverID);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderDateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OrderStatus = table.Column<string>(type: "TEXT", nullable: true),
                    CustID = table.Column<string>(type: "TEXT", nullable: true),
                    DriverID = table.Column<string>(type: "TEXT", nullable: true),
                    CustomerCustID = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerCustID",
                        column: x => x.CustomerCustID,
                        principalTable: "Customer",
                        principalColumn: "CustID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Driver_DriverID",
                        column: x => x.DriverID,
                        principalTable: "Driver",
                        principalColumn: "DriverID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerCustID",
                table: "Order",
                column: "CustomerCustID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_DriverID",
                table: "Order",
                column: "DriverID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Driver");
        }
    }
}
