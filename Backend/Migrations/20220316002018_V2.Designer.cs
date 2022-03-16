﻿// <auto-generated />
using System;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Backend.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20220316002018_V2")]
    partial class V2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Backend.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BuyerID")
                        .HasColumnType("int");

                    b.Property<int?>("FromStoreID")
                        .HasColumnType("int");

                    b.Property<int?>("PartID")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int")
                        .HasColumnName("Price");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("Quantity");

                    b.HasKey("ID");

                    b.HasIndex("BuyerID");

                    b.HasIndex("FromStoreID");

                    b.HasIndex("PartID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Backend.Models.PCPart", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Price")
                        .HasColumnType("int")
                        .HasColumnName("Price");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ProductName");

                    b.Property<int>("SerialNumber")
                        .HasMaxLength(5)
                        .HasColumnType("int")
                        .HasColumnName("SerialNumber");

                    b.HasKey("ID");

                    b.ToTable("PCPart");
                });

            modelBuilder.Entity("Backend.Models.PCStore", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)")
                        .HasColumnName("Name");

                    b.Property<string>("StoreLocation")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("StoreLocation");

                    b.Property<string>("StoreMailAdress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("StoreMailAdress");

                    b.Property<int>("StorePhoneNumber")
                        .HasMaxLength(15)
                        .HasColumnType("int")
                        .HasColumnName("StorePhoneNumber");

                    b.HasKey("ID");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("Backend.Models.UserAccount", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Address");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("City");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("LastName");

                    b.Property<string>("MailAddress")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("nvarchar(320)")
                        .HasColumnName("MailAddress");

                    b.Property<int>("PhoneNumber")
                        .HasMaxLength(15)
                        .HasColumnType("int")
                        .HasColumnName("PhoneNumber");

                    b.Property<int>("PostalCode")
                        .HasColumnType("int")
                        .HasColumnName("PostalCode");

                    b.HasKey("ID");

                    b.ToTable("UserAccount");
                });

            modelBuilder.Entity("PCPartPCStore", b =>
                {
                    b.Property<int>("AvailableInStoresID")
                        .HasColumnType("int");

                    b.Property<int>("PartsInStoreID")
                        .HasColumnType("int");

                    b.HasKey("AvailableInStoresID", "PartsInStoreID");

                    b.HasIndex("PartsInStoreID");

                    b.ToTable("PCPartPCStore");
                });

            modelBuilder.Entity("Backend.Models.Order", b =>
                {
                    b.HasOne("Backend.Models.UserAccount", "Buyer")
                        .WithMany("Orders")
                        .HasForeignKey("BuyerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.PCStore", "FromStore")
                        .WithMany()
                        .HasForeignKey("FromStoreID");

                    b.HasOne("Backend.Models.PCPart", "Part")
                        .WithMany()
                        .HasForeignKey("PartID");

                    b.Navigation("Buyer");

                    b.Navigation("FromStore");

                    b.Navigation("Part");
                });

            modelBuilder.Entity("PCPartPCStore", b =>
                {
                    b.HasOne("Backend.Models.PCStore", null)
                        .WithMany()
                        .HasForeignKey("AvailableInStoresID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.PCPart", null)
                        .WithMany()
                        .HasForeignKey("PartsInStoreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Models.UserAccount", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
