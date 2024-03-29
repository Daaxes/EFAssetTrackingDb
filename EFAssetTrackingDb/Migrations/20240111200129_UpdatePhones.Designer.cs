﻿// <auto-generated />
using System;
using EFAssetTrackingDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFAssetTrackingDb.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240111200129_UpdatePhones")]
    partial class UpdatePhones
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EFAssetTrackingDb.Computer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OfficeId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId");

                    b.ToTable("Computers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "HP",
                            Model = "Spectre x360",
                            OfficeId = 1,
                            Price = 1180,
                            PurchaseDate = new DateTime(2022, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "2in1 Laptop"
                        },
                        new
                        {
                            Id = 2,
                            Brand = "HP",
                            Model = "Envy x360",
                            OfficeId = 1,
                            Price = 1180,
                            PurchaseDate = new DateTime(2022, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "2in1 Laptop"
                        },
                        new
                        {
                            Id = 3,
                            Brand = "Dell",
                            Model = "Latetude XPS",
                            OfficeId = 3,
                            Price = 1220,
                            PurchaseDate = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "2in1 Laptop"
                        },
                        new
                        {
                            Id = 4,
                            Brand = "Dell",
                            Model = "Alienware",
                            OfficeId = 4,
                            Price = 1855,
                            PurchaseDate = new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Stationär"
                        });
                });

            modelBuilder.Entity("EFAssetTrackingDb.HQ", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("HQCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HQName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HQs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HQCountry = "Sweden",
                            HQName = "Stockholm"
                        },
                        new
                        {
                            Id = 2,
                            HQCountry = "Denmark",
                            HQName = "Copenhagen"
                        });
                });

            modelBuilder.Entity("EFAssetTrackingDb.Office", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HQId")
                        .HasColumnType("int");

                    b.Property<string>("OfficeCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OfficeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HQId");

                    b.ToTable("Offices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HQId = 1,
                            OfficeCountry = "Sverige",
                            OfficeName = "SveaKontoret"
                        },
                        new
                        {
                            Id = 2,
                            HQId = 2,
                            OfficeCountry = "Denmark",
                            OfficeName = "ZooKontoret"
                        },
                        new
                        {
                            Id = 3,
                            HQId = 2,
                            OfficeCountry = "Kroatien",
                            OfficeName = "SisakUred"
                        },
                        new
                        {
                            Id = 4,
                            HQId = 1,
                            OfficeCountry = "Norge",
                            OfficeName = "OsloKontoret"
                        },
                        new
                        {
                            Id = 5,
                            HQId = 1,
                            OfficeCountry = "Norge",
                            OfficeName = "HelsinkiToimisto"
                        });
                });

            modelBuilder.Entity("EFAssetTrackingDb.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OfficeId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId");

                    b.ToTable("Phones");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Apple",
                            Model = "Iphone 15 Pro Max",
                            OfficeId = 1,
                            Price = 1406,
                            PurchaseDate = new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Smartphone"
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Apple",
                            Model = "Iphone 13",
                            OfficeId = 4,
                            Price = 781,
                            PurchaseDate = new DateTime(2021, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Smartphone"
                        },
                        new
                        {
                            Id = 3,
                            Brand = "Samsung",
                            Model = "S23 Ultra",
                            OfficeId = 2,
                            Price = 1016,
                            PurchaseDate = new DateTime(2023, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Smartphone"
                        },
                        new
                        {
                            Id = 4,
                            Brand = "Google",
                            Model = "Pixel 8 Pro",
                            OfficeId = 1,
                            Price = 1023,
                            PurchaseDate = new DateTime(2023, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Smartphone"
                        },
                        new
                        {
                            Id = 5,
                            Brand = "Doro",
                            Model = "901c",
                            OfficeId = 1,
                            Price = 27,
                            PurchaseDate = new DateTime(2020, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Smartphone"
                        },
                        new
                        {
                            Id = 6,
                            Brand = "Iphone",
                            Model = "X",
                            OfficeId = 4,
                            Price = 632,
                            PurchaseDate = new DateTime(2020, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Smartphone"
                        },
                        new
                        {
                            Id = 7,
                            Brand = "Samsung",
                            Model = "Galaxy S10",
                            OfficeId = 5,
                            Price = 752,
                            PurchaseDate = new DateTime(2020, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Smartphone"
                        });
                });

            modelBuilder.Entity("EFAssetTrackingDb.Computer", b =>
                {
                    b.HasOne("EFAssetTrackingDb.Office", "Office")
                        .WithMany("ComputerList")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Office");
                });

            modelBuilder.Entity("EFAssetTrackingDb.Office", b =>
                {
                    b.HasOne("EFAssetTrackingDb.HQ", null)
                        .WithMany("Office")
                        .HasForeignKey("HQId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFAssetTrackingDb.Phone", b =>
                {
                    b.HasOne("EFAssetTrackingDb.Office", "Office")
                        .WithMany("PhoneList")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Office");
                });

            modelBuilder.Entity("EFAssetTrackingDb.HQ", b =>
                {
                    b.Navigation("Office");
                });

            modelBuilder.Entity("EFAssetTrackingDb.Office", b =>
                {
                    b.Navigation("ComputerList");

                    b.Navigation("PhoneList");
                });
#pragma warning restore 612, 618
        }
    }
}
