using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Slijterij.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Forename = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Forename = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => new { x.OrderID, x.ProductID });
                });

            migrationBuilder.CreateTable(
                name: "Origins",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origins", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TypesOfWhiskey",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfWhiskey", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginID = table.Column<int>(nullable: false),
                    TypeID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    AlcoholByVolume = table.Column<double>(nullable: false),
                    Price = table.Column<decimal>(type: "Money", nullable: false),
                    Image = table.Column<byte[]>(nullable: true),
                    AmountInStock = table.Column<int>(nullable: false),
                    Available = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Origins_OriginID",
                        column: x => x.OriginID,
                        principalTable: "Origins",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_TypesOfWhiskey_TypeID",
                        column: x => x.TypeID,
                        principalTable: "TypesOfWhiskey",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Origins",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Highland" },
                    { 2, "Lowland" }
                });

            migrationBuilder.InsertData(
                table: "TypesOfWhiskey",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Single malt" },
                    { 2, "Blended malt" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Age", "AlcoholByVolume", "AmountInStock", "Available", "Image", "Name", "OriginID", "Price", "TypeID" },
                values: new object[,]
                {
                    { 2, 10, 40.0, 15, false, null, "Oak", 1, 49.99m, 1 },
                    { 3, 21, 40.0, 11, true, null, "Hammer Head", 2, 50.00m, 1 },
                    { 1, 30, 40.0, 1, true, null, "Seaweed", 2, 499.99m, 2 },
                    { 4, 8, 40.0, 23, true, null, "Frysk Hynder", 1, 9.99m, 2 },
                    { 5, 12, 40.0, 7, false, null, "Smoke", 1, 99.95m, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeeID",
                table: "Orders",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_OriginID",
                table: "Products",
                column: "OriginID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TypeID",
                table: "Products",
                column: "TypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Origins");

            migrationBuilder.DropTable(
                name: "TypesOfWhiskey");
        }
    }
}
