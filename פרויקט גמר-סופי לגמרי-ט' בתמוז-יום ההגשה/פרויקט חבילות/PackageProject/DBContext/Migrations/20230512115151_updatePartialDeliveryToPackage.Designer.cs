﻿// <auto-generated />
using System;
using DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DBContext.Migrations
{
    [DbContext(typeof(PackageProject4Context))]
    [Migration("20230512115151_updatePartialDeliveryToPackage")]
    partial class updatePartialDeliveryToPackage
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Repositories.Entities.BusinessDay", b =>
                {
                    b.Property<int>("BusinessDayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("businessDayID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BusinessDayId"));

                    b.Property<int?>("BusinessDayNubmer")
                        .HasColumnType("int")
                        .HasColumnName("businessDayNubmer");

                    b.HasKey("BusinessDayId");

                    b.ToTable("businessDays", (string)null);
                });

            modelBuilder.Entity("Repositories.Entities.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("clientID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("firstName")
                        .HasDefaultValueSql("(N'')");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("lastName")
                        .HasDefaultValueSql("(N'')");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("mail")
                        .HasDefaultValueSql("(N'')");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("phone")
                        .HasDefaultValueSql("(N'')");

                    b.HasKey("ClientId");

                    b.ToTable("clients", (string)null);
                });

            modelBuilder.Entity("Repositories.Entities.CollectingPoint", b =>
                {
                    b.Property<int>("CollectingPointId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("collectingPointId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CollectingPointId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("address")
                        .HasDefaultValueSql("(N'')");

                    b.Property<int>("ColPointType")
                        .HasColumnType("int");

                    b.Property<string>("CollectingPointName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("collectingPointName");

                    b.Property<decimal?>("LocationX")
                        .HasColumnType("decimal(18, 0)")
                        .HasColumnName("locationX");

                    b.Property<decimal?>("LocationY")
                        .HasColumnType("decimal(18, 0)")
                        .HasColumnName("locationY");

                    b.HasKey("CollectingPointId")
                        .HasName("PK_CollectingPoints");

                    b.ToTable("collectingPoints", (string)null);
                });

            modelBuilder.Entity("Repositories.Entities.Delivery", b =>
                {
                    b.Property<int>("DeliveryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("deliveryID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeliveryId"));

                    b.Property<int>("BusinessDayId")
                        .HasColumnType("int")
                        .HasColumnName("businessDayID");

                    b.Property<int>("PackageId")
                        .HasColumnType("int")
                        .HasColumnName("packageID");

                    b.Property<decimal>("SourceLocationX")
                        .HasColumnType("decimal(18, 0)")
                        .HasColumnName("sourceLocationX");

                    b.Property<decimal>("SourceLocationY")
                        .HasColumnType("decimal(18, 0)")
                        .HasColumnName("sourceLocationY");

                    b.HasKey("DeliveryId");

                    b.HasIndex(new[] { "BusinessDayId" }, "IX_deliveries_businessDayID");

                    b.HasIndex(new[] { "PackageId" }, "IX_deliveries_packageID");

                    b.ToTable("deliveries", (string)null);
                });

            modelBuilder.Entity("Repositories.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("employeeID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("address")
                        .HasDefaultValueSql("(N'')");

                    b.Property<DateTime?>("CompanyEntryDate")
                        .HasColumnType("datetime")
                        .HasColumnName("companyEntryDate");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("firstName")
                        .HasDefaultValueSql("(N'')");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("lastName")
                        .HasDefaultValueSql("(N'')");

                    b.Property<decimal?>("LocationX")
                        .HasColumnType("decimal(18, 0)")
                        .HasColumnName("locationX");

                    b.Property<decimal?>("LocationY")
                        .HasColumnType("decimal(18, 0)")
                        .HasColumnName("locationY");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("mail")
                        .HasDefaultValueSql("(N'')");

                    b.Property<string>("Password")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("password")
                        .HasDefaultValueSql("(N'')");

                    b.Property<string>("Phone")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("phone")
                        .HasDefaultValueSql("(N'')");

                    b.Property<int?>("UserLevel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("userLevel")
                        .HasDefaultValueSql("((1))");

                    b.HasKey("EmployeeId");

                    b.ToTable("employees", (string)null);
                });

            modelBuilder.Entity("Repositories.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("orderID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("BusinessDayId")
                        .HasColumnType("int")
                        .HasColumnName("businessDayID");

                    b.Property<int>("ClientId")
                        .HasColumnType("int")
                        .HasColumnName("clientID");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime")
                        .HasColumnName("date");

                    b.Property<int>("PackageId")
                        .HasColumnType("int")
                        .HasColumnName("packageID");

                    b.HasKey("OrderId");

                    b.HasIndex(new[] { "BusinessDayId" }, "IX_orders_businessDayID");

                    b.HasIndex(new[] { "ClientId" }, "IX_orders_clientID");

                    b.HasIndex(new[] { "PackageId" }, "IX_orders_packageID");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("Repositories.Entities.Package", b =>
                {
                    b.Property<int>("PackageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("packageID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PackageId"));

                    b.Property<string>("AddressDestination")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("addressDestination")
                        .HasDefaultValueSql("(N'')");

                    b.Property<string>("AddressSource")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("addressSource")
                        .HasDefaultValueSql("(N'')");

                    b.Property<int>("ClientId")
                        .HasColumnType("int")
                        .HasColumnName("clientID");

                    b.Property<decimal?>("DestinationLocationX")
                        .HasColumnType("decimal(18, 0)")
                        .HasColumnName("destinationLocationX");

                    b.Property<decimal?>("DestinationLocationY")
                        .HasColumnType("decimal(18, 0)")
                        .HasColumnName("destinationLocationY");

                    b.Property<decimal?>("SourceLocationX")
                        .HasColumnType("decimal(18, 0)")
                        .HasColumnName("sourceLocationX");

                    b.Property<decimal?>("SourceLocationY")
                        .HasColumnType("decimal(18, 0)")
                        .HasColumnName("sourceLocationY");

                    b.HasKey("PackageId");

                    b.HasIndex(new[] { "ClientId" }, "IX_packages_clientID");

                    b.ToTable("packages", (string)null);
                });

            modelBuilder.Entity("Repositories.Entities.PartialDelivery", b =>
                {
                    b.Property<int>("PartialDeliveryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("partialDeliveryID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PartialDeliveryId"));

                    b.Property<int>("CollectingPointId")
                        .HasColumnType("int")
                        .HasColumnName("collectingPointId");

                    b.Property<int>("DeliveryId")
                        .HasColumnType("int")
                        .HasColumnName("deliveryId");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("employeeID");

                    b.Property<int>("IndexOfDelivery")
                        .HasColumnType("int")
                        .HasColumnName("indexOfDelivery");

                    b.Property<decimal?>("IntermediateDestinationLocationX")
                        .HasColumnType("decimal(18, 0)")
                        .HasColumnName("intermediateDestinationLocationX");

                    b.Property<decimal?>("IntermediateDestinationLocationY")
                        .HasColumnType("decimal(18, 0)")
                        .HasColumnName("intermediateDestinationLocationY");

                    b.Property<decimal?>("IntermediateSourceLocationX")
                        .HasColumnType("decimal(18, 0)")
                        .HasColumnName("intermediateSourceLocationX");

                    b.Property<decimal?>("IntermediateSourceLocationY")
                        .HasColumnType("decimal(18, 0)")
                        .HasColumnName("intermediateSourceLocationY");

                    b.HasKey("PartialDeliveryId");

                    b.HasIndex(new[] { "CollectingPointId" }, "IX_partialDelivery_collectingPointId");

                    b.HasIndex(new[] { "DeliveryId" }, "IX_partialDelivery_deliveryId");

                    b.HasIndex(new[] { "EmployeeId" }, "IX_partialDelivery_employeeID");

                    b.ToTable("partialDelivery", (string)null);
                });

            modelBuilder.Entity("Repositories.Entities.PartialDeliveryToPackage", b =>
                {
                    b.Property<int>("PartialDeliveryToPackageId")
                        .HasColumnType("int")
                        .HasColumnName("PartialDeliveryToPackagesId");

                    b.Property<int>("IsTakenOrDownloaded")
                        .HasColumnType("int")
                        .HasColumnName("isTakenOrDownloaded");

                    b.Property<int>("PackageId")
                        .HasColumnType("int")
                        .HasColumnName("packageId");

                    b.Property<int>("PartialDeliveryId")
                        .HasColumnType("int")
                        .HasColumnName("partialDeliveryId");

                    b.HasKey("PartialDeliveryToPackageId");

                    b.ToTable("PartialDeliveryToPackages", (string)null);
                });

            modelBuilder.Entity("Repositories.Entities.Delivery", b =>
                {
                    b.HasOne("Repositories.Entities.BusinessDay", "BusinessDay")
                        .WithMany("Deliveries")
                        .HasForeignKey("BusinessDayId")
                        .IsRequired()
                        .HasConstraintName("FK_deliveries_businessDays");

                    b.HasOne("Repositories.Entities.Package", "Package")
                        .WithMany("Deliveries")
                        .HasForeignKey("PackageId")
                        .IsRequired()
                        .HasConstraintName("FK_deliveries_packages");

                    b.Navigation("BusinessDay");

                    b.Navigation("Package");
                });

            modelBuilder.Entity("Repositories.Entities.Order", b =>
                {
                    b.HasOne("Repositories.Entities.BusinessDay", "BusinessDay")
                        .WithMany("Orders")
                        .HasForeignKey("BusinessDayId")
                        .IsRequired()
                        .HasConstraintName("FK_orders_businessDays");

                    b.HasOne("Repositories.Entities.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .IsRequired()
                        .HasConstraintName("FK_orders_clients");

                    b.HasOne("Repositories.Entities.Package", "Package")
                        .WithMany("Orders")
                        .HasForeignKey("PackageId")
                        .IsRequired()
                        .HasConstraintName("FK_orders_packages");

                    b.Navigation("BusinessDay");

                    b.Navigation("Client");

                    b.Navigation("Package");
                });

            modelBuilder.Entity("Repositories.Entities.Package", b =>
                {
                    b.HasOne("Repositories.Entities.Client", "Client")
                        .WithMany("Packages")
                        .HasForeignKey("ClientId")
                        .IsRequired()
                        .HasConstraintName("FK_packages_clients");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Repositories.Entities.PartialDelivery", b =>
                {
                    b.HasOne("Repositories.Entities.CollectingPoint", "CollectingPoint")
                        .WithMany("PartialDeliveries")
                        .HasForeignKey("CollectingPointId")
                        .IsRequired()
                        .HasConstraintName("FK_partialDelivery_collectingPoints");

                    b.HasOne("Repositories.Entities.Delivery", "Delivery")
                        .WithMany("PartialDeliveries")
                        .HasForeignKey("DeliveryId")
                        .IsRequired()
                        .HasConstraintName("FK_partialDelivery_deliveries");

                    b.HasOne("Repositories.Entities.Employee", "Employee")
                        .WithMany("PartialDeliveries")
                        .HasForeignKey("EmployeeId")
                        .IsRequired()
                        .HasConstraintName("FK_partialDelivery_employees");

                    b.Navigation("CollectingPoint");

                    b.Navigation("Delivery");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Repositories.Entities.PartialDeliveryToPackage", b =>
                {
                    b.HasOne("Repositories.Entities.PartialDelivery", "PartialDeliveryToPackageNavigation")
                        .WithOne("PartialDeliveryToPackage")
                        .HasForeignKey("Repositories.Entities.PartialDeliveryToPackage", "PartialDeliveryToPackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_PartialDeliveryToPackages_partialDelivery");

                    b.Navigation("PartialDeliveryToPackageNavigation");
                });

            modelBuilder.Entity("Repositories.Entities.BusinessDay", b =>
                {
                    b.Navigation("Deliveries");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Repositories.Entities.Client", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Packages");
                });

            modelBuilder.Entity("Repositories.Entities.CollectingPoint", b =>
                {
                    b.Navigation("PartialDeliveries");
                });

            modelBuilder.Entity("Repositories.Entities.Delivery", b =>
                {
                    b.Navigation("PartialDeliveries");
                });

            modelBuilder.Entity("Repositories.Entities.Employee", b =>
                {
                    b.Navigation("PartialDeliveries");
                });

            modelBuilder.Entity("Repositories.Entities.Package", b =>
                {
                    b.Navigation("Deliveries");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Repositories.Entities.PartialDelivery", b =>
                {
                    b.Navigation("PartialDeliveryToPackage");
                });
#pragma warning restore 612, 618
        }
    }
}
