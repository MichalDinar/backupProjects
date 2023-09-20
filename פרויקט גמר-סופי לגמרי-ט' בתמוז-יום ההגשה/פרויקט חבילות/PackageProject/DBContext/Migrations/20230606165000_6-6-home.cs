using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class _66home : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "intermediateDestinationLocationX",
                table: "partialDelivery");

            migrationBuilder.DropColumn(
                name: "intermediateDestinationLocationY",
                table: "partialDelivery");

            migrationBuilder.DropColumn(
                name: "intermediateSourceLocationX",
                table: "partialDelivery");

            migrationBuilder.DropColumn(
                name: "intermediateSourceLocationY",
                table: "partialDelivery");

            migrationBuilder.AddColumn<DateTime>(
                name: "estimatedTimeOfArrival",
                table: "partialDelivery",
                type: "date",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "estimatedTimeOfArrival",
                table: "partialDelivery");

            migrationBuilder.AddColumn<decimal>(
                name: "intermediateDestinationLocationX",
                table: "partialDelivery",
                type: "decimal(18,0)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "intermediateDestinationLocationY",
                table: "partialDelivery",
                type: "decimal(18,0)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "intermediateSourceLocationX",
                table: "partialDelivery",
                type: "decimal(18,0)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "intermediateSourceLocationY",
                table: "partialDelivery",
                type: "decimal(18,0)",
                nullable: true);
        }
    }
}
