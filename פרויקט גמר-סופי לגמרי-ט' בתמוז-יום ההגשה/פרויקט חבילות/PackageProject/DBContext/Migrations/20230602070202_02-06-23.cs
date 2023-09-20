using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class _020623 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_clients",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_partialDelivery_deliveries",
                table: "partialDelivery");

            migrationBuilder.DropForeignKey(
                name: "FK_PartialDeliveryToPackages_partialDelivery",
                table: "PartialDeliveryToPackages");

            migrationBuilder.DropTable(
                name: "deliveries");

            migrationBuilder.DropIndex(
                name: "IX_partialDelivery_deliveryId",
                table: "partialDelivery");

            migrationBuilder.DropIndex(
                name: "IX_orders_clientID",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "deliveryId",
                table: "partialDelivery");

            migrationBuilder.DropColumn(
                name: "clientID",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "employeeID",
                table: "partialDelivery",
                newName: "employeeId");

            migrationBuilder.RenameColumn(
                name: "partialDeliveryID",
                table: "partialDelivery",
                newName: "partialDeliveryId");

            migrationBuilder.RenameColumn(
                name: "clientID",
                table: "packages",
                newName: "clientId");

            migrationBuilder.RenameColumn(
                name: "packageID",
                table: "packages",
                newName: "packageId");

            migrationBuilder.RenameColumn(
                name: "packageID",
                table: "orders",
                newName: "packageId");

            migrationBuilder.RenameColumn(
                name: "businessDayID",
                table: "orders",
                newName: "businessDayId");

            migrationBuilder.RenameColumn(
                name: "orderID",
                table: "orders",
                newName: "orderId");

            migrationBuilder.RenameColumn(
                name: "employeeID",
                table: "employees",
                newName: "employeeId");

            migrationBuilder.RenameColumn(
                name: "clientID",
                table: "clients",
                newName: "clientId");

            migrationBuilder.RenameColumn(
                name: "businessDayID",
                table: "businessDays",
                newName: "businessDayId");

            migrationBuilder.AlterColumn<int>(
                name: "PartialDeliveryToPackagesId",
                table: "PartialDeliveryToPackages",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "businessDayId",
                table: "partialDelivery",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "sourceLocationY",
                table: "packages",
                type: "decimal(18,14)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "sourceLocationX",
                table: "packages",
                type: "decimal(18,14)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "destinationLocationY",
                table: "packages",
                type: "decimal(18,14)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "destinationLocationX",
                table: "packages",
                type: "decimal(18,14)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "collectingPointId",
                table: "packages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "state",
                table: "packages",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "locationY",
                table: "employees",
                type: "decimal(18,14)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "locationX",
                table: "employees",
                type: "decimal(18,14)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "locationY",
                table: "collectingPoints",
                type: "decimal(18,14)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "locationX",
                table: "collectingPoints",
                type: "decimal(18,14)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PartialDeliveryToPackages_packageId",
                table: "PartialDeliveryToPackages",
                column: "packageId");

            migrationBuilder.CreateIndex(
                name: "IX_PartialDeliveryToPackages_partialDeliveryId",
                table: "PartialDeliveryToPackages",
                column: "partialDeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_partialDelivery_businessDayId",
                table: "partialDelivery",
                column: "businessDayId");

            migrationBuilder.CreateIndex(
                name: "IX_packages_collectingPointId",
                table: "packages",
                column: "collectingPointId");

            migrationBuilder.AddForeignKey(
                name: "FK_packages_collectingPoints",
                table: "packages",
                column: "collectingPointId",
                principalTable: "collectingPoints",
                principalColumn: "collectingPointId");

            migrationBuilder.AddForeignKey(
                name: "FK_partialDelivery_businessDays",
                table: "partialDelivery",
                column: "businessDayId",
                principalTable: "businessDays",
                principalColumn: "businessDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartialDeliveryToPackages_packages",
                table: "PartialDeliveryToPackages",
                column: "packageId",
                principalTable: "packages",
                principalColumn: "packageId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartialDeliveryToPackages_partialDelivery",
                table: "PartialDeliveryToPackages",
                column: "partialDeliveryId",
                principalTable: "partialDelivery",
                principalColumn: "partialDeliveryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_packages_collectingPoints",
                table: "packages");

            migrationBuilder.DropForeignKey(
                name: "FK_partialDelivery_businessDays",
                table: "partialDelivery");

            migrationBuilder.DropForeignKey(
                name: "FK_PartialDeliveryToPackages_packages",
                table: "PartialDeliveryToPackages");

            migrationBuilder.DropForeignKey(
                name: "FK_PartialDeliveryToPackages_partialDelivery",
                table: "PartialDeliveryToPackages");

            migrationBuilder.DropIndex(
                name: "IX_PartialDeliveryToPackages_packageId",
                table: "PartialDeliveryToPackages");

            migrationBuilder.DropIndex(
                name: "IX_PartialDeliveryToPackages_partialDeliveryId",
                table: "PartialDeliveryToPackages");

            migrationBuilder.DropIndex(
                name: "IX_partialDelivery_businessDayId",
                table: "partialDelivery");

            migrationBuilder.DropIndex(
                name: "IX_packages_collectingPointId",
                table: "packages");

            migrationBuilder.DropColumn(
                name: "businessDayId",
                table: "partialDelivery");

            migrationBuilder.DropColumn(
                name: "collectingPointId",
                table: "packages");

            migrationBuilder.DropColumn(
                name: "state",
                table: "packages");

            migrationBuilder.RenameColumn(
                name: "employeeId",
                table: "partialDelivery",
                newName: "employeeID");

            migrationBuilder.RenameColumn(
                name: "partialDeliveryId",
                table: "partialDelivery",
                newName: "partialDeliveryID");

            migrationBuilder.RenameColumn(
                name: "clientId",
                table: "packages",
                newName: "clientID");

            migrationBuilder.RenameColumn(
                name: "packageId",
                table: "packages",
                newName: "packageID");

            migrationBuilder.RenameColumn(
                name: "packageId",
                table: "orders",
                newName: "packageID");

            migrationBuilder.RenameColumn(
                name: "businessDayId",
                table: "orders",
                newName: "businessDayID");

            migrationBuilder.RenameColumn(
                name: "orderId",
                table: "orders",
                newName: "orderID");

            migrationBuilder.RenameColumn(
                name: "employeeId",
                table: "employees",
                newName: "employeeID");

            migrationBuilder.RenameColumn(
                name: "clientId",
                table: "clients",
                newName: "clientID");

            migrationBuilder.RenameColumn(
                name: "businessDayId",
                table: "businessDays",
                newName: "businessDayID");

            migrationBuilder.AlterColumn<int>(
                name: "PartialDeliveryToPackagesId",
                table: "PartialDeliveryToPackages",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "deliveryId",
                table: "partialDelivery",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "sourceLocationY",
                table: "packages",
                type: "decimal(18,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,14)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "sourceLocationX",
                table: "packages",
                type: "decimal(18,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,14)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "destinationLocationY",
                table: "packages",
                type: "decimal(18,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,14)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "destinationLocationX",
                table: "packages",
                type: "decimal(18,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,14)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "clientID",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "locationY",
                table: "employees",
                type: "decimal(18,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,14)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "locationX",
                table: "employees",
                type: "decimal(18,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,14)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "locationY",
                table: "collectingPoints",
                type: "decimal(18,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,14)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "locationX",
                table: "collectingPoints",
                type: "decimal(18,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,14)",
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_partialDelivery_deliveryId",
                table: "partialDelivery",
                column: "deliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_clientID",
                table: "orders",
                column: "clientID");

            migrationBuilder.CreateIndex(
                name: "IX_deliveries_businessDayID",
                table: "deliveries",
                column: "businessDayID");

            migrationBuilder.CreateIndex(
                name: "IX_deliveries_packageID",
                table: "deliveries",
                column: "packageID");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_clients",
                table: "orders",
                column: "clientID",
                principalTable: "clients",
                principalColumn: "clientID");

            migrationBuilder.AddForeignKey(
                name: "FK_partialDelivery_deliveries",
                table: "partialDelivery",
                column: "deliveryId",
                principalTable: "deliveries",
                principalColumn: "deliveryID");

            migrationBuilder.AddForeignKey(
                name: "FK_PartialDeliveryToPackages_partialDelivery",
                table: "PartialDeliveryToPackages",
                column: "PartialDeliveryToPackagesId",
                principalTable: "partialDelivery",
                principalColumn: "partialDeliveryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
