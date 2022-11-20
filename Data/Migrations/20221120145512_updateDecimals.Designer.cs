﻿// <auto-generated />
using System;
using Marinel_ui.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Marinel.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20221120145512_updateDecimals")]
    partial class updateDecimals
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Marinel_ui.Data.Entities.BookSale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("InventoryItemId")
                        .HasColumnType("int");

                    b.Property<int>("NoOfBooksSold")
                        .HasColumnType("int");

                    b.Property<decimal>("Revenue")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("InventoryItemId");

                    b.ToTable("BookSales");
                });

            modelBuilder.Entity("Marinel_ui.Data.Entities.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PinkAndCheckUniformPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Classes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Creche",
                            PinkAndCheckUniformPrice = 95m
                        },
                        new
                        {
                            Id = 2,
                            Name = "Nursery",
                            PinkAndCheckUniformPrice = 100m
                        },
                        new
                        {
                            Id = 3,
                            Name = "Nursery 2A",
                            PinkAndCheckUniformPrice = 100m
                        },
                        new
                        {
                            Id = 4,
                            Name = "Nursery 2B",
                            PinkAndCheckUniformPrice = 100m
                        },
                        new
                        {
                            Id = 5,
                            Name = "KG1",
                            PinkAndCheckUniformPrice = 100m
                        },
                        new
                        {
                            Id = 6,
                            Name = "KG2",
                            PinkAndCheckUniformPrice = 100m
                        },
                        new
                        {
                            Id = 7,
                            Name = "CLASS 1",
                            PinkAndCheckUniformPrice = 105m
                        },
                        new
                        {
                            Id = 8,
                            Name = "CLASS 2",
                            PinkAndCheckUniformPrice = 105m
                        },
                        new
                        {
                            Id = 9,
                            Name = "CLASS 3",
                            PinkAndCheckUniformPrice = 105m
                        },
                        new
                        {
                            Id = 10,
                            Name = "CLASS 4",
                            PinkAndCheckUniformPrice = 105m
                        },
                        new
                        {
                            Id = 11,
                            Name = "CLASS 5",
                            PinkAndCheckUniformPrice = 105m
                        },
                        new
                        {
                            Id = 12,
                            Name = "CLASS 6",
                            PinkAndCheckUniformPrice = 105m
                        },
                        new
                        {
                            Id = 13,
                            Name = "JHS 1",
                            PinkAndCheckUniformPrice = 110m
                        },
                        new
                        {
                            Id = 14,
                            Name = "JHS 2",
                            PinkAndCheckUniformPrice = 110m
                        },
                        new
                        {
                            Id = 15,
                            Name = "JHS 3",
                            PinkAndCheckUniformPrice = 110m
                        });
                });

            modelBuilder.Entity("Marinel_ui.Data.Entities.ClassFeeInfoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("AmountReceived")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberEnrolled")
                        .HasColumnType("int");

                    b.Property<int>("NumberPaid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ClassFeeInfoItems");
                });

            modelBuilder.Entity("Marinel_ui.Data.Entities.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("Marinel_ui.Data.Entities.ExpenseType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ExpenseTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Stationery"
                        });
                });

            modelBuilder.Entity("Marinel_ui.Data.Entities.FeedingExpense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("ExpenseAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ExpenseReason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FeedingInfoItemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FeedingInfoItemId");

                    b.ToTable("FeedingExpenses");
                });

            modelBuilder.Entity("Marinel_ui.Data.Entities.FeedingInfoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberOfStudents")
                        .HasColumnType("int");

                    b.Property<decimal>("Revenue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalCollected")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("FeedingInfoItems");
                });

            modelBuilder.Entity("Marinel_ui.Data.Entities.InventoryItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("CostPerUnit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("InventoryTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("SellingPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("InventoryTypeId");

                    b.ToTable("InventoryItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CostPerUnit = 10m,
                            InventoryTypeId = 1,
                            Name = "SMALL NOTEBOOK",
                            Quantity = 100,
                            SellingPrice = 10m
                        },
                        new
                        {
                            Id = 2,
                            CostPerUnit = 10m,
                            InventoryTypeId = 1,
                            Name = "MEDIUM NOTEBOOK",
                            Quantity = 100,
                            SellingPrice = 10m
                        },
                        new
                        {
                            Id = 3,
                            CostPerUnit = 10m,
                            InventoryTypeId = 1,
                            Name = "EXERCISE BOOKS",
                            Quantity = 100,
                            SellingPrice = 10m
                        },
                        new
                        {
                            Id = 4,
                            CostPerUnit = 10m,
                            InventoryTypeId = 2,
                            Name = "CRECHE UNIFORM",
                            Quantity = 100,
                            SellingPrice = 10m
                        },
                        new
                        {
                            Id = 5,
                            CostPerUnit = 10m,
                            InventoryTypeId = 2,
                            Name = "WEDNESDAY WEAR UNIFORM",
                            Quantity = 100,
                            SellingPrice = 10m
                        },
                        new
                        {
                            Id = 6,
                            CostPerUnit = 10m,
                            InventoryTypeId = 2,
                            Name = "FRIDAY WEAR UNIFORM",
                            Quantity = 100,
                            SellingPrice = 10m
                        },
                        new
                        {
                            Id = 7,
                            CostPerUnit = 0m,
                            InventoryTypeId = 3,
                            Name = "PINK MATERIAL",
                            Quantity = 100,
                            SellingPrice = 0m
                        },
                        new
                        {
                            Id = 8,
                            CostPerUnit = 0m,
                            InventoryTypeId = 3,
                            Name = "CHECK MATERIAL",
                            Quantity = 100,
                            SellingPrice = 0m
                        });
                });

            modelBuilder.Entity("Marinel_ui.Data.Entities.InventoryType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("InventoryTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Book"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Uniform"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Material"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("Marinel_ui.Data.Entities.PandCUniformSale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CheckYardsQuantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatePaid")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PaidInFull")
                        .HasColumnType("bit");

                    b.Property<int>("PinkYardsQuantity")
                        .HasColumnType("int");

                    b.Property<bool>("Received")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ReceivedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("SeamstressPaid")
                        .HasColumnType("bit");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalCollected")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("PandCUniformSales");
                });

            modelBuilder.Entity("Marinel_ui.Data.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClassId = 1,
                            DOB = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Elijah"
                        },
                        new
                        {
                            Id = 4,
                            ClassId = 2,
                            DOB = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "TJ"
                        });
                });

            modelBuilder.Entity("Marinel_ui.Data.Entities.UniformSale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("InventoryItemId")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PaidInFull")
                        .HasColumnType("bit");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<bool>("Received")
                        .HasColumnType("bit");

                    b.Property<decimal>("Revenue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StockDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InventoryItemId");

                    b.HasIndex("StudentId");

                    b.ToTable("UniformSales");
                });

            modelBuilder.Entity("Marinel_ui.Data.Entities.BookSale", b =>
                {
                    b.HasOne("Marinel_ui.Data.Entities.InventoryItem", "InventoryItem")
                        .WithMany()
                        .HasForeignKey("InventoryItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InventoryItem");
                });

            modelBuilder.Entity("Marinel_ui.Data.Entities.Expense", b =>
                {
                    b.HasOne("Marinel_ui.Data.Entities.ExpenseType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Marinel_ui.Data.Entities.FeedingExpense", b =>
                {
                    b.HasOne("Marinel_ui.Data.Entities.FeedingInfoItem", null)
                        .WithMany("FeedingExpenses")
                        .HasForeignKey("FeedingInfoItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Marinel_ui.Data.Entities.InventoryItem", b =>
                {
                    b.HasOne("Marinel_ui.Data.Entities.InventoryType", "InventoryType")
                        .WithMany()
                        .HasForeignKey("InventoryTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InventoryType");
                });

            modelBuilder.Entity("Marinel_ui.Data.Entities.PandCUniformSale", b =>
                {
                    b.HasOne("Marinel_ui.Data.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Marinel_ui.Data.Entities.Student", b =>
                {
                    b.HasOne("Marinel_ui.Data.Entities.Class", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("Marinel_ui.Data.Entities.UniformSale", b =>
                {
                    b.HasOne("Marinel_ui.Data.Entities.InventoryItem", "InventoryItem")
                        .WithMany()
                        .HasForeignKey("InventoryItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Marinel_ui.Data.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InventoryItem");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Marinel_ui.Data.Entities.Class", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Marinel_ui.Data.Entities.FeedingInfoItem", b =>
                {
                    b.Navigation("FeedingExpenses");
                });
#pragma warning restore 612, 618
        }
    }
}
