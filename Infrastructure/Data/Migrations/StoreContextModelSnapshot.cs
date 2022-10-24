﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(StoreContext))]
    partial class StoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("Core.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PortalPassword")
                        .HasColumnType("text");

                    b.Property<string>("PortalUser")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("Core.Entities.Donator", b =>
                {
                    b.Property<string>("DonatorUID")
                        .HasMaxLength(38)
                        .HasColumnType("char(38)");

                    b.Property<string>("Address")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Address2")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("DefaultToken")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("EmployeeUID")
                        .HasMaxLength(38)
                        .HasColumnType("char(38)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("ImageURL")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<float>("Latitude")
                        .HasColumnType("float");

                    b.Property<float>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("MobileNumber")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("PortalPassword")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("PortalUser")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Suburb")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Surname")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("DonatorUID");

                    b.HasIndex("CountryId");

                    b.ToTable("Donator");
                });

            modelBuilder.Entity("Core.Entities.Employee", b =>
                {
                    b.Property<string>("EmployeeUID")
                        .HasMaxLength(38)
                        .HasColumnType("char(38)");

                    b.Property<string>("Address")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Address2")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("DefaultToken")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("ImageURL")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<float>("Latitude")
                        .HasColumnType("float");

                    b.Property<float>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("MobileNumber")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("PortalPassword")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("PortalUser")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Suburb")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Surname")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("EmployeeUID");

                    b.HasIndex("CountryId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Core.Entities.OrderAggregate.DeliveryMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DeliveryTime")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ShortName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DeliveryMethod");
                });

            modelBuilder.Entity("Core.Entities.OrderAggregate.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BuyerEmail")
                        .HasColumnType("text");

                    b.Property<int?>("DeliveryMethodId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime");

                    b.Property<string>("PaymentIntentId")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryMethodId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Core.Entities.OrderAggregate.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("Core.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ImageURL")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.Property<string>("StoreUID")
                        .HasMaxLength(38)
                        .HasColumnType("char(38)");

                    b.HasKey("Id");

                    b.HasIndex("ProductTypeId");

                    b.HasIndex("StoreUID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Core.Entities.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("ProductType");
                });

            modelBuilder.Entity("Core.Entities.Recipient", b =>
                {
                    b.Property<string>("RecipientUID")
                        .HasMaxLength(38)
                        .HasColumnType("char(38)");

                    b.Property<string>("Address")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Address2")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("DefaultToken")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("EmployeeUID")
                        .HasMaxLength(38)
                        .HasColumnType("char(38)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("ImageURL")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<float>("Latitude")
                        .HasColumnType("float");

                    b.Property<float>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("MobileNumber")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Nickname")
                        .HasColumnType("text");

                    b.Property<string>("PortalPassword")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("PortalUser")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Suburb")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Surname")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("RecipientUID");

                    b.HasIndex("CountryId");

                    b.ToTable("Recipient");
                });

            modelBuilder.Entity("Core.Entities.Store", b =>
                {
                    b.Property<string>("StoreUID")
                        .HasMaxLength(38)
                        .HasColumnType("char(38)");

                    b.Property<string>("Address")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Address2")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("DefaultToken")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FullName")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("ImageURL")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<float>("Latitude")
                        .HasColumnType("float");

                    b.Property<float>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("MobileNumber")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Nickname")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PortalPassword")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("PortalUser")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Suburb")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Surname")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("StoreUID");

                    b.HasIndex("CountryId");

                    b.ToTable("Store");
                });

            modelBuilder.Entity("Core.Entities.StoreRecipient", b =>
                {
                    b.Property<string>("StoreRecipientUID")
                        .HasMaxLength(38)
                        .HasColumnType("char(38)");

                    b.Property<DateTime>("DateRegistered")
                        .HasColumnType("datetime");

                    b.Property<string>("EmployeeUID")
                        .HasMaxLength(38)
                        .HasColumnType("char(38)");

                    b.Property<string>("RecipientUID")
                        .HasMaxLength(38)
                        .HasColumnType("char(38)");

                    b.Property<string>("StoreUID")
                        .HasMaxLength(38)
                        .HasColumnType("char(38)");

                    b.HasKey("StoreRecipientUID");

                    b.HasIndex("RecipientUID");

                    b.HasIndex("StoreUID");

                    b.ToTable("StoreRecipient");
                });

            modelBuilder.Entity("Core.Entities.Token", b =>
                {
                    b.Property<string>("TokenUID")
                        .HasMaxLength(38)
                        .HasColumnType("char(38)");

                    b.Property<float>("CostPrice")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateAssigned")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateCollected")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateExpire")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateRelease")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateStoreAssigned")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("DonatorName")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("DonatorUID")
                        .HasMaxLength(38)
                        .HasColumnType("char(38)");

                    b.Property<ulong>("FoodCollected")
                        .HasColumnType("bit");

                    b.Property<string>("ImageURL")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("RecipientName")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("RecipientUID")
                        .HasMaxLength(38)
                        .HasColumnType("char(38)");

                    b.Property<float>("SalesPrice")
                        .HasColumnType("float");

                    b.Property<string>("ShortURL")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("StoreMealUID")
                        .HasMaxLength(38)
                        .HasColumnType("char(38)");

                    b.Property<string>("StoreUID")
                        .HasMaxLength(38)
                        .HasColumnType("char(38)");

                    b.Property<string>("TokenName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<ulong>("Valid")
                        .HasColumnType("bit");

                    b.HasKey("TokenUID");

                    b.HasIndex("DonatorUID");

                    b.HasIndex("ProductId");

                    b.HasIndex("RecipientUID");

                    b.HasIndex("StoreUID");

                    b.ToTable("Token");
                });

            modelBuilder.Entity("Core.Entities.TokenMessage", b =>
                {
                    b.Property<int>("TokenMessageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateSent")
                        .HasColumnType("datetime");

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("EmailText")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<ulong>("IsSent")
                        .HasColumnType("bit");

                    b.Property<string>("MessageText")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("MessageType")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("SMSPortalUID")
                        .HasMaxLength(38)
                        .HasColumnType("char(38)");

                    b.Property<string>("TokenUID")
                        .IsRequired()
                        .HasMaxLength(38)
                        .HasColumnType("char(38)");

                    b.HasKey("TokenMessageID");

                    b.ToTable("TokenMessage");
                });

            modelBuilder.Entity("Core.Entities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("CostPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DatePurchased")
                        .HasColumnType("datetime");

                    b.Property<string>("DonatorUID")
                        .HasMaxLength(38)
                        .HasColumnType("char(38)");

                    b.Property<string>("EmployeeUID")
                        .HasMaxLength(38)
                        .HasColumnType("char(38)");

                    b.Property<int>("MealsPerMonth")
                        .HasColumnType("int");

                    b.Property<int>("MealsPerWeek")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<bool>("Recurring")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("StoreUID")
                        .HasMaxLength(38)
                        .HasColumnType("char(38)");

                    b.HasKey("Id");

                    b.HasIndex("DonatorUID");

                    b.HasIndex("ProductId");

                    b.HasIndex("StoreUID");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("Core.Entities.Donator", b =>
                {
                    b.HasOne("Core.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Core.Entities.Employee", b =>
                {
                    b.HasOne("Core.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Core.Entities.OrderAggregate.Order", b =>
                {
                    b.HasOne("Core.Entities.OrderAggregate.DeliveryMethod", "DeliveryMethod")
                        .WithMany()
                        .HasForeignKey("DeliveryMethodId");

                    b.OwnsOne("Core.Entities.OrderAggregate.Address", "ShipToAddress", b1 =>
                        {
                            b1.Property<int>("OrderId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .HasColumnType("text");

                            b1.Property<string>("FirstName")
                                .HasColumnType("text");

                            b1.Property<string>("LastName")
                                .HasColumnType("text");

                            b1.Property<string>("State")
                                .HasColumnType("text");

                            b1.Property<string>("Street")
                                .HasColumnType("text");

                            b1.Property<string>("ZipCode")
                                .HasColumnType("text");

                            b1.HasKey("OrderId");

                            b1.ToTable("Address");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("DeliveryMethod");

                    b.Navigation("ShipToAddress")
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.OrderAggregate.OrderItem", b =>
                {
                    b.HasOne("Core.Entities.OrderAggregate.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("Core.Entities.OrderAggregate.ProductItemOrdered", "ItemOrdered", b1 =>
                        {
                            b1.Property<int>("OrderItemId")
                                .HasColumnType("int");

                            b1.Property<string>("ImageURL")
                                .HasColumnType("text");

                            b1.Property<int>("ProductItemId")
                                .HasColumnType("int");

                            b1.Property<string>("ProductName")
                                .HasColumnType("text");

                            b1.HasKey("OrderItemId");

                            b1.ToTable("ProductItemOrdered");

                            b1.WithOwner()
                                .HasForeignKey("OrderItemId");
                        });

                    b.Navigation("ItemOrdered");
                });

            modelBuilder.Entity("Core.Entities.Product", b =>
                {
                    b.HasOne("Core.Entities.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreUID");

                    b.Navigation("ProductType");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Core.Entities.Recipient", b =>
                {
                    b.HasOne("Core.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Core.Entities.Store", b =>
                {
                    b.HasOne("Core.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Core.Entities.StoreRecipient", b =>
                {
                    b.HasOne("Core.Entities.Recipient", "Recipient")
                        .WithMany()
                        .HasForeignKey("RecipientUID");

                    b.HasOne("Core.Entities.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreUID");

                    b.Navigation("Recipient");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Core.Entities.Token", b =>
                {
                    b.HasOne("Core.Entities.Donator", "Donator")
                        .WithMany()
                        .HasForeignKey("DonatorUID");

                    b.HasOne("Core.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Recipient", "Recipient")
                        .WithMany()
                        .HasForeignKey("RecipientUID");

                    b.HasOne("Core.Entities.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreUID");

                    b.Navigation("Donator");

                    b.Navigation("Product");

                    b.Navigation("Recipient");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Core.Entities.Transaction", b =>
                {
                    b.HasOne("Core.Entities.Donator", "Donator")
                        .WithMany()
                        .HasForeignKey("DonatorUID");

                    b.HasOne("Core.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreUID");

                    b.Navigation("Donator");

                    b.Navigation("Product");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Core.Entities.OrderAggregate.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
