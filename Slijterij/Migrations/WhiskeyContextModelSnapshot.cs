﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Slijterij.DAL;

namespace Slijterij.Migrations
{
    [DbContext(typeof(WhiskeyContext))]
    partial class WhiskeyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Slijterij.Models.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Forename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Slijterij.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Slijterij.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("Date");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Slijterij.Models.OrderProduct", b =>
                {
                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.HasKey("OrderID", "ProductID");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("Slijterij.Models.Origin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Origins");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Highland"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Lowland"
                        });
                });

            modelBuilder.Entity("Slijterij.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<double>("AlcoholByVolume")
                        .HasColumnType("float");

                    b.Property<int>("AmountInStock")
                        .HasColumnType("int");

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OriginID")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("Money");

                    b.Property<int>("TypeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("OriginID");

                    b.HasIndex("TypeID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Age = 30,
                            AlcoholByVolume = 40.0,
                            AmountInStock = 1,
                            Available = true,
                            Name = "Seaweed",
                            OriginID = 2,
                            Price = 499.99m,
                            TypeID = 2
                        },
                        new
                        {
                            ID = 2,
                            Age = 10,
                            AlcoholByVolume = 40.0,
                            AmountInStock = 15,
                            Available = false,
                            Name = "Oak",
                            OriginID = 1,
                            Price = 49.99m,
                            TypeID = 1
                        },
                        new
                        {
                            ID = 3,
                            Age = 21,
                            AlcoholByVolume = 40.0,
                            AmountInStock = 11,
                            Available = true,
                            Name = "Hammer Head",
                            OriginID = 2,
                            Price = 50.00m,
                            TypeID = 1
                        },
                        new
                        {
                            ID = 4,
                            Age = 8,
                            AlcoholByVolume = 40.0,
                            AmountInStock = 23,
                            Available = true,
                            Name = "Frysk Hynder",
                            OriginID = 1,
                            Price = 9.99m,
                            TypeID = 2
                        },
                        new
                        {
                            ID = 5,
                            Age = 12,
                            AlcoholByVolume = 40.0,
                            AmountInStock = 7,
                            Available = false,
                            Name = "Smoke",
                            OriginID = 1,
                            Price = 99.95m,
                            TypeID = 2
                        });
                });

            modelBuilder.Entity("Slijterij.Models.TypeOfWhiskey", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TypesOfWhiskey");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Single malt"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Blended malt"
                        });
                });

            modelBuilder.Entity("Slijterij.Models.Order", b =>
                {
                    b.HasOne("Slijterij.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Slijterij.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Slijterij.Models.OrderProduct", b =>
                {
                    b.HasOne("Slijterij.Models.Order", null)
                        .WithMany("Products")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Slijterij.Models.Product", b =>
                {
                    b.HasOne("Slijterij.Models.Origin", "Origin")
                        .WithMany()
                        .HasForeignKey("OriginID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Slijterij.Models.TypeOfWhiskey", "Type")
                        .WithMany()
                        .HasForeignKey("TypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
