using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProject001.Migrations
{
    /// <inheritdoc />
    public partial class WebProject001CreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WebProject001_Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebProject001_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WebProject001_PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebProject001_PaymentMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WebProject001_Shops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebProject001_Shops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WebProject001_Expenditures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenditureDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ExpenditureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebProject001_Expenditures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebProject001_Expenditures_WebProject001_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "WebProject001_Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WebProject001_Expenditures_WebProject001_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "WebProject001_PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WebProject001_Expenditures_WebProject001_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "WebProject001_Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WebProject001_Expenditures_CategoryId",
                table: "WebProject001_Expenditures",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WebProject001_Expenditures_PaymentMethodId",
                table: "WebProject001_Expenditures",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_WebProject001_Expenditures_ShopId",
                table: "WebProject001_Expenditures",
                column: "ShopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WebProject001_Expenditures");

            migrationBuilder.DropTable(
                name: "WebProject001_Categories");

            migrationBuilder.DropTable(
                name: "WebProject001_PaymentMethods");

            migrationBuilder.DropTable(
                name: "WebProject001_Shops");
        }
    }
}
