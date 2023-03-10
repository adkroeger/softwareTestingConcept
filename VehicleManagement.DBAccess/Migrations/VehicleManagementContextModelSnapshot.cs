// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VehicleManagement.DBAccess;

#nullable disable

namespace VehicleManagement.DBAccess.Migrations
{
    [DbContext(typeof(VehicleManagementContext))]
    partial class VehicleManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("VehicleManagement.DBAccess.Entities.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("EmployeeNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<string>("FIN")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FIN");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("VehicleManagement.DBAccess.Entities.Manufacturer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Manufacturer");
                });

            modelBuilder.Entity("VehicleManagement.DBAccess.Entities.Vehicle", b =>
                {
                    b.Property<string>("FIN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicensePlate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManufacturerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Mileage")
                        .HasColumnType("float");

                    b.HasKey("FIN");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("VehicleManagement.DBAccess.Entities.Booking", b =>
                {
                    b.HasOne("VehicleManagement.DBAccess.Entities.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("FIN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("VehicleManagement.DBAccess.Entities.Vehicle", b =>
                {
                    b.HasOne("VehicleManagement.DBAccess.Entities.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerId");

                    b.Navigation("Manufacturer");
                });
#pragma warning restore 612, 618
        }
    }
}
