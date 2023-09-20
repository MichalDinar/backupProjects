using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Entities;

namespace DBContext;

public partial class PackageProject4Context : DbContext, IContext
{
    public PackageProject4Context()
    {
    }

    public PackageProject4Context(DbContextOptions<PackageProject4Context> options)
        : base(options)
    {
    }

    public virtual DbSet<BusinessDay> BusinessDays { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<CollectingPoint> CollectingPoints { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Package> Packages { get; set; }

    public virtual DbSet<PartialDelivery> PartialDeliveries { get; set; }

    public virtual DbSet<PartialDeliveryToPackage> PartialDeliveryToPackages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PackageProject4;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
    //  => optionsBuilder.UseSqlServer("Data Source=SEMINAR-SQL\\MTM;Initial Catalog=PackageProject4;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BusinessDay>(entity =>
        {
            entity.ToTable("businessDays");

            entity.Property(e => e.BusinessDayId).HasColumnName("businessDayId");
            entity.Property(e => e.BusinessDayNubmer).HasColumnName("businessDayNubmer");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("clients");

            entity.Property(e => e.ClientId).HasColumnName("clientId");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'')")
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'')")
                .HasColumnName("lastName");
            entity.Property(e => e.Mail)
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'')")
                .HasColumnName("mail");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'')")
                .HasColumnName("phone");
        });

        modelBuilder.Entity<CollectingPoint>(entity =>
        {
            entity.HasKey(e => e.CollectingPointId).HasName("PK_CollectingPoints");

            entity.ToTable("collectingPoints");

            entity.Property(e => e.CollectingPointId).HasColumnName("collectingPointId");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'')")
                .HasColumnName("address");
            entity.Property(e => e.CollectingPointName)
                .HasMaxLength(50)
                .HasColumnName("collectingPointName");
            entity.Property(e => e.LocationX)
                .HasColumnType("decimal(18, 14)")
                .HasColumnName("locationX");
            entity.Property(e => e.LocationY)
                .HasColumnType("decimal(18, 14)")
                .HasColumnName("locationY");
            entity.Property(e => e.PackageId).HasColumnName("packageId");
            entity.Property(e => e.State).HasColumnName("state");

            entity.HasOne(d => d.Package).WithMany(p => p.CollectingPoints)
                .HasForeignKey(d => d.PackageId)
                .HasConstraintName("FK_collectingPoints_packages");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("employees");

            entity.Property(e => e.EmployeeId).HasColumnName("employeeId");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'')")
                .HasColumnName("address");
            entity.Property(e => e.CompanyEntryDate)
                .HasColumnType("datetime")
                .HasColumnName("companyEntryDate");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'')")
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'')")
                .HasColumnName("lastName");
            entity.Property(e => e.LocationX)
                .HasColumnType("decimal(18, 14)")
                .HasColumnName("locationX");
            entity.Property(e => e.LocationY)
                .HasColumnType("decimal(18, 14)")
                .HasColumnName("locationY");
            entity.Property(e => e.Mail)
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'')")
                .HasColumnName("mail");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'')")
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'')")
                .HasColumnName("phone");
            entity.Property(e => e.UserLevel)
                .HasDefaultValueSql("((1))")
                .HasColumnName("userLevel");
        });

        modelBuilder.Entity<Package>(entity =>
        {
            entity.ToTable("packages");

            entity.HasIndex(e => e.ClientId, "IX_packages_clientID");

            entity.Property(e => e.PackageId).HasColumnName("packageId");
            entity.Property(e => e.AddressDestination)
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'')")
                .HasColumnName("addressDestination");
            entity.Property(e => e.AddressSource)
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'')")
                .HasColumnName("addressSource");
            entity.Property(e => e.ClientId).HasColumnName("clientId");
            entity.Property(e => e.CollectingPointId).HasColumnName("collectingPointId");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.DestinationLocationX)
                .HasColumnType("decimal(18, 14)")
                .HasColumnName("destinationLocationX");
            entity.Property(e => e.DestinationLocationY)
                .HasColumnType("decimal(18, 14)")
                .HasColumnName("destinationLocationY");
            entity.Property(e => e.SourceLocationX)
                .HasColumnType("decimal(18, 14)")
                .HasColumnName("sourceLocationX");
            entity.Property(e => e.SourceLocationY)
                .HasColumnType("decimal(18, 14)")
                .HasColumnName("sourceLocationY");
            entity.Property(e => e.State).HasColumnName("state");

            entity.HasOne(d => d.Client).WithMany(p => p.Packages)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_packages_clients");

            entity.HasOne(d => d.CollectingPoint).WithMany(p => p.Packages)
                .HasForeignKey(d => d.CollectingPointId)
                .HasConstraintName("FK_packages_collectingPoints");
        });

        modelBuilder.Entity<PartialDelivery>(entity =>
        {
            entity.ToTable("partialDelivery");

            entity.HasIndex(e => e.CollectingPointId, "IX_partialDelivery_collectingPointId");

            entity.HasIndex(e => e.EmployeeId, "IX_partialDelivery_employeeID");

            entity.Property(e => e.PartialDeliveryId).HasColumnName("partialDeliveryId");
            entity.Property(e => e.BusinessDayId).HasColumnName("businessDayId");
            entity.Property(e => e.CollectingPointId).HasColumnName("collectingPointId");
            entity.Property(e => e.EmployeeId).HasColumnName("employeeId");
            entity.Property(e => e.EstimatedTimeOfArrival).HasColumnType("datetime");
            entity.Property(e => e.IndexOfDelivery).HasColumnName("indexOfDelivery");

            entity.HasOne(d => d.BusinessDay).WithMany(p => p.PartialDeliveries)
                .HasForeignKey(d => d.BusinessDayId)
                .HasConstraintName("FK_partialDelivery_businessDays");

            entity.HasOne(d => d.CollectingPoint).WithMany(p => p.PartialDeliveries)
                .HasForeignKey(d => d.CollectingPointId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_partialDelivery_collectingPoints");

            entity.HasOne(d => d.Employee).WithMany(p => p.PartialDeliveries)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_partialDelivery_employees");
        });

        modelBuilder.Entity<PartialDeliveryToPackage>(entity =>
        {
            entity.HasKey(e => e.PartialDeliveryToPackagesId);

            entity.Property(e => e.IsTakenOrDownloaded).HasColumnName("isTakenOrDownloaded");
            entity.Property(e => e.PackageId).HasColumnName("packageId");
            entity.Property(e => e.PartialDeliveryId).HasColumnName("partialDeliveryId");

            entity.HasOne(d => d.Package).WithMany(p => p.PartialDeliveryToPackages)
                .HasForeignKey(d => d.PackageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PartialDeliveryToPackages_packages");

            entity.HasOne(d => d.PartialDelivery).WithMany(p => p.PartialDeliveryToPackages)
                .HasForeignKey(d => d.PartialDeliveryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PartialDeliveryToPackages_partialDelivery");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
