// <auto-generated />
using CarBase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarBase.Migrations
{
    [DbContext(typeof(VehicleContext))]
    [Migration("20220403124723_InitialCreate7")]
    partial class InitialCreate7
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarBase.Models.engine", b =>
                {
                    b.Property<int>("engineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("engineID"), 1L, 1);

                    b.Property<string>("size")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("engineID");

                    b.ToTable("engine");
                });

            modelBuilder.Entity("CarBase.Models.FavoriteVehicles", b =>
                {
                    b.Property<int>("vehicleID")
                        .HasColumnType("int");

                    b.Property<int>("UsersID")
                        .HasColumnType("int");

                    b.HasKey("vehicleID", "UsersID");

                    b.HasIndex("UsersID");

                    b.ToTable("FavoriteVehicles");
                });

            modelBuilder.Entity("CarBase.Models.make", b =>
                {
                    b.Property<int>("makeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("makeID"), 1L, 1);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("makeID");

                    b.ToTable("make");
                });

            modelBuilder.Entity("CarBase.Models.RentedVehicles", b =>
                {
                    b.Property<int>("vehicleID")
                        .HasColumnType("int");

                    b.Property<int>("UsersID")
                        .HasColumnType("int");

                    b.HasKey("vehicleID", "UsersID");

                    b.HasIndex("UsersID");

                    b.ToTable("RentedVehicles");
                });

            modelBuilder.Entity("CarBase.Models.type", b =>
                {
                    b.Property<int>("typeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("typeID"), 1L, 1);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("typeID");

                    b.ToTable("type");
                });

            modelBuilder.Entity("CarBase.Models.Users", b =>
                {
                    b.Property<int>("UsersID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsersID"), 1L, 1);

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsersID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CarBase.Models.vehicle", b =>
                {
                    b.Property<int>("vehicleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("vehicleID"), 1L, 1);

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("engineID")
                        .HasColumnType("int");

                    b.Property<int>("horsepower")
                        .HasColumnType("int");

                    b.Property<string>("img_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("makeID")
                        .HasColumnType("int");

                    b.Property<string>("rent_status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("typeID")
                        .HasColumnType("int");

                    b.Property<int>("year")
                        .HasColumnType("int");

                    b.HasKey("vehicleID");

                    b.HasIndex("engineID");

                    b.HasIndex("makeID");

                    b.HasIndex("typeID");

                    b.ToTable("vehicles");
                });

            modelBuilder.Entity("CarBase.Models.FavoriteVehicles", b =>
                {
                    b.HasOne("CarBase.Models.Users", "Users")
                        .WithMany("FavoriteVehicles")
                        .HasForeignKey("UsersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarBase.Models.vehicle", "vehicle")
                        .WithMany("FavoriteVehicles")
                        .HasForeignKey("vehicleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");

                    b.Navigation("vehicle");
                });

            modelBuilder.Entity("CarBase.Models.RentedVehicles", b =>
                {
                    b.HasOne("CarBase.Models.Users", "Users")
                        .WithMany("RentedVehicles")
                        .HasForeignKey("UsersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarBase.Models.vehicle", "vehicle")
                        .WithMany("RentedVehicles")
                        .HasForeignKey("vehicleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");

                    b.Navigation("vehicle");
                });

            modelBuilder.Entity("CarBase.Models.vehicle", b =>
                {
                    b.HasOne("CarBase.Models.engine", "engine")
                        .WithMany("vehicle")
                        .HasForeignKey("engineID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarBase.Models.make", "make")
                        .WithMany("vehicle")
                        .HasForeignKey("makeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarBase.Models.type", "type")
                        .WithMany("vehicle")
                        .HasForeignKey("typeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("engine");

                    b.Navigation("make");

                    b.Navigation("type");
                });

            modelBuilder.Entity("CarBase.Models.engine", b =>
                {
                    b.Navigation("vehicle");
                });

            modelBuilder.Entity("CarBase.Models.make", b =>
                {
                    b.Navigation("vehicle");
                });

            modelBuilder.Entity("CarBase.Models.type", b =>
                {
                    b.Navigation("vehicle");
                });

            modelBuilder.Entity("CarBase.Models.Users", b =>
                {
                    b.Navigation("FavoriteVehicles");

                    b.Navigation("RentedVehicles");
                });

            modelBuilder.Entity("CarBase.Models.vehicle", b =>
                {
                    b.Navigation("FavoriteVehicles");

                    b.Navigation("RentedVehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
