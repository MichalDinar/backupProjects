using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "businessDays",
                columns: table => new
                {
                    businessDayID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    businessDayNubmer = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_businessDays", x => x.businessDayID);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    clientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "(N'')"),
                    lastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "(N'')"),
                    phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "(N'')"),
                    mail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "(N'')"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.clientID);
                });

            migrationBuilder.CreateTable(
                name: "collectingPoints",
                columns: table => new
                {
                    collectingPointId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    collectingPointName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    locationX = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    locationY = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    ColPointType = table.Column<int>(type: "int", nullable: false),
                    address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "(N'')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectingPoints", x => x.collectingPointId);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    employeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "(N'')"),
                    lastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "(N'')"),
                    companyEntryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "(N'')"),
                    locationX = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    locationY = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    mail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "(N'')"),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "(N'')"),
                    userLevel = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
                    address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "(N'')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.employeeID);
                });

            migrationBuilder.CreateTable(
                name: "packages",
                columns: table => new
                {
                    packageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sourceLocationX = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    sourceLocationY = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    destinationLocationX = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    destinationLocationY = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    clientID = table.Column<int>(type: "int", nullable: false),
                    addressDestination = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "(N'')"),
                    addressSource = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "(N'')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_packages", x => x.packageID);
                    table.ForeignKey(
                        name: "FK_packages_clients",
                        column: x => x.clientID,
                        principalTable: "clients",
                        principalColumn: "clientID");
                });

            migrationBuilder.CreateTable(
                name: "deliveries",
                columns: table => new
                {
                    deliveryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    businessDayID = table.Column<int>(type: "int", nullable: false),
                    packageID = table.Column<int>(type: "int", nullable: false),
                    sourceLocationX = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    sourceLocationY = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deliveries", x => x.deliveryID);
                    table.ForeignKey(
                        name: "FK_deliveries_businessDays",
                        column: x => x.businessDayID,
                        principalTable: "businessDays",
                        principalColumn: "businessDayID");
                    table.ForeignKey(
                        name: "FK_deliveries_packages",
                        column: x => x.packageID,
                        principalTable: "packages",
                        principalColumn: "packageID");
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    orderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clientID = table.Column<int>(type: "int", nullable: false),
                    businessDayID = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: true),
                    packageID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.orderID);
                    table.ForeignKey(
                        name: "FK_orders_businessDays",
                        column: x => x.businessDayID,
                        principalTable: "businessDays",
                        principalColumn: "businessDayID");
                    table.ForeignKey(
                        name: "FK_orders_clients",
                        column: x => x.clientID,
                        principalTable: "clients",
                        principalColumn: "clientID");
                    table.ForeignKey(
                        name: "FK_orders_packages",
                        column: x => x.packageID,
                        principalTable: "packages",
                        principalColumn: "packageID");
                });

            migrationBuilder.CreateTable(
                name: "partialDelivery",
                columns: table => new
                {
                    partialDeliveryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeID = table.Column<int>(type: "int", nullable: false),
                    intermediateSourceLocationX = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    intermediateSourceLocationY = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    intermediateDestinationLocationX = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    intermediateDestinationLocationY = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    collectingPointId = table.Column<int>(type: "int", nullable: false),
                    deliveryId = table.Column<int>(type: "int", nullable: false),
                    indexOfDelivery = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_partialDelivery", x => x.partialDeliveryID);
                    table.ForeignKey(
                        name: "FK_partialDelivery_collectingPoints",
                        column: x => x.collectingPointId,
                        principalTable: "collectingPoints",
                        principalColumn: "collectingPointId");
                    table.ForeignKey(
                        name: "FK_partialDelivery_deliveries",
                        column: x => x.deliveryId,
                        principalTable: "deliveries",
                        principalColumn: "deliveryID");
                    table.ForeignKey(
                        name: "FK_partialDelivery_employees",
                        column: x => x.employeeID,
                        principalTable: "employees",
                        principalColumn: "employeeID");
                });

            migrationBuilder.CreateTable(
                name: "PartialDeliveryToPackages",
                columns: table => new
                {
                    PartialDeliveryToPackagesId = table.Column<int>(type: "int", nullable: false),
                    packageId = table.Column<int>(type: "int", nullable: false),
                    isTakenOrDownloaded = table.Column<int>(type: "int", nullable: false),
                    partialDeliveryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartialDeliveryToPackages", x => x.PartialDeliveryToPackagesId);
                    table.ForeignKey(
                        name: "FK_PartialDeliveryToPackages_partialDelivery",
                        column: x => x.PartialDeliveryToPackagesId,
                        principalTable: "partialDelivery",
                        principalColumn: "partialDeliveryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_deliveries_businessDayID",
                table: "deliveries",
                column: "businessDayID");

            migrationBuilder.CreateIndex(
                name: "IX_deliveries_packageID",
                table: "deliveries",
                column: "packageID");

            migrationBuilder.CreateIndex(
                name: "IX_orders_businessDayID",
                table: "orders",
                column: "businessDayID");

            migrationBuilder.CreateIndex(
                name: "IX_orders_clientID",
                table: "orders",
                column: "clientID");

            migrationBuilder.CreateIndex(
                name: "IX_orders_packageID",
                table: "orders",
                column: "packageID");

            migrationBuilder.CreateIndex(
                name: "IX_packages_clientID",
                table: "packages",
                column: "clientID");

            migrationBuilder.CreateIndex(
                name: "IX_partialDelivery_collectingPointId",
                table: "partialDelivery",
                column: "collectingPointId");

            migrationBuilder.CreateIndex(
                name: "IX_partialDelivery_deliveryId",
                table: "partialDelivery",
                column: "deliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_partialDelivery_employeeID",
                table: "partialDelivery",
                column: "employeeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "PartialDeliveryToPackages");

            migrationBuilder.DropTable(
                name: "partialDelivery");

            migrationBuilder.DropTable(
                name: "collectingPoints");

            migrationBuilder.DropTable(
                name: "deliveries");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "businessDays");

            migrationBuilder.DropTable(
                name: "packages");

            migrationBuilder.DropTable(
                name: "clients");
        }
    }
}
