﻿// <auto-generated />
using System;
using DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DBContext.Migrations
{
    [DbContext(typeof(PackageProject4Context))]
    partial class PackageProject3ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasColumnName("businessDayId");

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
                        .HasColumnName("clientId");

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
                        .HasColumnType("decimal(18, 14)")
                        .HasColumnName("locationX");

                    b.Property<decimal?>("LocationY")
                        .HasColumnType("decimal(18, 14)")
                        .HasColumnName("locationY");

                    b.HasKey("CollectingPointId")
                        .HasName("PK_CollectingPoints");

                    b.ToTable("collectingPoints", (string)null);
                });

            modelBuilder.Entity("Repositories.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("employeeId");

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
                        .HasColumnType("decimal(18, 14)")
                        .HasColumnName("locationX");

                    b.Property<decimal?>("LocationY")
                        .HasColumnType("decimal(18, 14)")
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
                        .HasColumnName("orderId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("BusinessDayId")
                        .HasColumnType("int")
                        .HasColumnName("businessDayId");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime")
                        .HasColumnName("date");

                    b.Property<int>("PackageId")
                        .HasColumnType("int")
                        .HasColumnName("packageId");

                    b.HasKey("OrderId");

                    b.HasIndex(new[] { "BusinessDayId" }, "IX_orders_businessDayID");

                    b.HasIndex(new[] { "PackageId" }, "IX_orders_packageID");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("Repositories.Entities.Package", b =>
                {
                    b.Property<int>("PackageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("packageId");

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
                        .HasColumnName("clientId");

                    b.Property<int?>("CollectingPointId")
                        .HasColumnType("int")
                        .HasColumnName("collectingPointId");

                    b.Property<decimal?>("DestinationLocationX")
                        .HasColumnType("decimal(18, 14)")
                        .HasColumnName("destinationLocationX");

                    b.Property<decimal?>("DestinationLocationY")
                        .HasColumnType("decimal(18, 14)")
                        .HasColumnName("destinationLocationY");

                    b.Property<decimal?>("SourceLocationX")
                        .HasColumnType("decimal(18, 14)")
                        .HasColumnName("sourceLocationX");

                    b.Property<decimal?>("SourceLocationY")
                        .HasColumnType("decimal(18, 14)")
                        .HasColumnName("sourceLocationY");

                    b.Property<int?>("State")
                        .HasColumnType("int")
                        .HasColumnName("state");

                    b.HasKey("PackageId");

                    b.HasIndex("CollectingPointId");

                    b.HasIndex(new[] { "ClientId" }, "IX_packages_clientID");

                    b.ToTable("packages", (string)null);
                });

            modelBuilder.Entity("Repositories.Entities.PartialDelivery", b =>
                {
                    b.Property<int>("PartialDeliveryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("partialDeliveryId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PartialDeliveryId"));

                    b.Property<int?>("BusinessDayId")
                        .HasColumnType("int")
                        .HasColumnName("businessDayId");

                    b.Property<int>("CollectingPointId")
                        .HasColumnType("int")
                        .HasColumnName("collectingPointId");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("employeeId");

                    b.Property<DateTime?>("EstimatedTimeOfArrival")
                        .HasColumnType("date")
                        .HasColumnName("estimatedTimeOfArrival");

                    b.Property<int>("IndexOfDelivery")
                        .HasColumnType("int")
                        .HasColumnName("indexOfDelivery");

                    b.HasKey("PartialDeliveryId");

                    b.HasIndex("BusinessDayId");

                    b.HasIndex(new[] { "CollectingPointId" }, "IX_partialDelivery_collectingPointId");

                    b.HasIndex(new[] { "EmployeeId" }, "IX_partialDelivery_employeeID");

                    b.ToTable("partialDelivery", (string)null);
                });

            modelBuilder.Entity("Repositories.Entities.PartialDeliveryToPackage", b =>
                {
                    b.Property<int>("PartialDeliveryToPackagesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PartialDeliveryToPackagesId"));

                    b.Property<int>("IsTakenOrDownloaded")
                        .HasColumnType("int")
                        .HasColumnName("isTakenOrDownloaded");

                    b.Property<int>("PackageId")
                        .HasColumnType("int")
                        .HasColumnName("packageId");

                    b.Property<int>("PartialDeliveryId")
                        .HasColumnType("int")
                        .HasColumnName("partialDeliveryId");

                    b.HasKey("PartialDeliveryToPackagesId");

                    b.HasIndex("PackageId");

                    b.HasIndex("PartialDeliveryId");

                    b.ToTable("PartialDeliveryToPackages");
                });

            modelBuilder.Entity("Repositories.Entities.Order", b =>
                {
                    b.HasOne("Repositories.Entities.BusinessDay", "BusinessDay")
                        .WithMany("Orders")
                        .HasForeignKey("BusinessDayId")
                        .IsRequired()
                        .HasConstraintName("FK_orders_businessDays");

                    b.HasOne("Repositories.Entities.Package", "Package")
                        .WithMany("Orders")
                        .HasForeignKey("PackageId")
                        .IsRequired()
                        .HasConstraintName("FK_orders_packages");

                    b.Navigation("BusinessDay");

                    b.Navigation("Package");
                });

            modelBuilder.Entity("Repositories.Entities.Package", b =>
                {
                    b.HasOne("Repositories.Entities.Client", "Client")
                        .WithMany("Packages")
                        .HasForeignKey("ClientId")
                        .IsRequired()
                        .HasConstraintName("FK_packages_clients");

                    b.HasOne("Repositories.Entities.CollectingPoint", "CollectingPoint")
                        .WithMany("Packages")
                        .HasForeignKey("CollectingPointId")
                        .HasConstraintName("FK_packages_collectingPoints");

                    b.Navigation("Client");

                    b.Navigation("CollectingPoint");
                });

            modelBuilder.Entity("Repositories.Entities.PartialDelivery", b =>
                {
                    b.HasOne("Repositories.Entities.BusinessDay", "BusinessDay")
                        .WithMany("PartialDeliveries")
                        .HasForeignKey("BusinessDayId")
                        .HasConstraintName("FK_partialDelivery_businessDays");

                    b.HasOne("Repositories.Entities.CollectingPoint", "CollectingPoint")
                        .WithMany("PartialDeliveries")
                        .HasForeignKey("CollectingPointId")
                        .IsRequired()
                        .HasConstraintName("FK_partialDelivery_collectingPoints");

                    b.HasOne("Repositories.Entities.Employee", "Employee")
                        .WithMany("PartialDeliveries")
                        .HasForeignKey("EmployeeId")
                        .IsRequired()
                        .HasConstraintName("FK_partialDelivery_employees");

                    b.Navigation("BusinessDay");

                    b.Navigation("CollectingPoint");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Repositories.Entities.PartialDeliveryToPackage", b =>
                {
                    b.HasOne("Repositories.Entities.Package", "Package")
                        .WithMany("PartialDeliveryToPackages")
                        .HasForeignKey("PackageId")
                        .IsRequired()
                        .HasConstraintName("FK_PartialDeliveryToPackages_packages");

                    b.HasOne("Repositories.Entities.PartialDelivery", "PartialDelivery")
                        .WithMany("PartialDeliveryToPackages")
                        .HasForeignKey("PartialDeliveryId")
                        .IsRequired()
                        .HasConstraintName("FK_PartialDeliveryToPackages_partialDelivery");

                    b.Navigation("Package");

                    b.Navigation("PartialDelivery");
                });

            modelBuilder.Entity("Repositories.Entities.BusinessDay", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("PartialDeliveries");
                });

            modelBuilder.Entity("Repositories.Entities.Client", b =>
                {
                    b.Navigation("Packages");
                });

            modelBuilder.Entity("Repositories.Entities.CollectingPoint", b =>
                {
                    b.Navigation("Packages");

                    b.Navigation("PartialDeliveries");
                });

            modelBuilder.Entity("Repositories.Entities.Employee", b =>
                {
                    b.Navigation("PartialDeliveries");
                });

            modelBuilder.Entity("Repositories.Entities.Package", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("PartialDeliveryToPackages");
                });

            modelBuilder.Entity("Repositories.Entities.PartialDelivery", b =>
                {
                    b.Navigation("PartialDeliveryToPackages");
                });
#pragma warning restore 612, 618
        }
    }
}
