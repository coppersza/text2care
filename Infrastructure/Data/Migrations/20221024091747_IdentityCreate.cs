﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Infrastructure.Data.Migrations
{
    public partial class IdentityCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    PortalUser = table.Column<string>(type: "text", nullable: true),
                    PortalPassword = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryMethod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ShortName = table.Column<string>(type: "text", nullable: true),
                    DeliveryTime = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TokenMessage",
                columns: table => new
                {
                    TokenMessageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TokenUID = table.Column<string>(type: "char(38)", maxLength: 38, nullable: false),
                    SMSPortalUID = table.Column<string>(type: "char(38)", maxLength: 38, nullable: true),
                    MessageText = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    MessageType = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true),
                    EmailAddress = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    EmailText = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    DateSent = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsSent = table.Column<ulong>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenMessage", x => x.TokenMessageID);
                });

            migrationBuilder.CreateTable(
                name: "Donator",
                columns: table => new
                {
                    DonatorUID = table.Column<string>(type: "char(38)", maxLength: 38, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Surname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    FullName = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    MobileNumber = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true),
                    EmailAddress = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Address = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Address2 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Suburb = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    PostalCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    DefaultToken = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    ImageURL = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    PortalUser = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true),
                    PortalPassword = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true),
                    Latitude = table.Column<float>(type: "float", nullable: false),
                    Longitude = table.Column<float>(type: "float", nullable: false),
                    EmployeeUID = table.Column<string>(type: "char(38)", maxLength: 38, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donator", x => x.DonatorUID);
                    table.ForeignKey(
                        name: "FK_Donator_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeUID = table.Column<string>(type: "char(38)", maxLength: 38, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Surname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    FullName = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    MobileNumber = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true),
                    EmailAddress = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Address = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Address2 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Suburb = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    PostalCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    DefaultToken = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    ImageURL = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    PortalUser = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true),
                    PortalPassword = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true),
                    Latitude = table.Column<float>(type: "float", nullable: false),
                    Longitude = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeUID);
                    table.ForeignKey(
                        name: "FK_Employee_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipient",
                columns: table => new
                {
                    RecipientUID = table.Column<string>(type: "char(38)", maxLength: 38, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Surname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    FullName = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    Nickname = table.Column<string>(type: "text", nullable: true),
                    MobileNumber = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true),
                    EmailAddress = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Address = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Address2 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Suburb = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    PostalCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    DefaultToken = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    ImageURL = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    PortalUser = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true),
                    PortalPassword = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true),
                    Latitude = table.Column<float>(type: "float", nullable: false),
                    Longitude = table.Column<float>(type: "float", nullable: false),
                    EmployeeUID = table.Column<string>(type: "char(38)", maxLength: 38, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipient", x => x.RecipientUID);
                    table.ForeignKey(
                        name: "FK_Recipient_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    StoreUID = table.Column<string>(type: "char(38)", maxLength: 38, nullable: false),
                    StoreName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Surname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    FullName = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Nickname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    MobileNumber = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true),
                    EmailAddress = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Address = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Address2 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Suburb = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    PostalCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    DefaultToken = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    ImageURL = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    PortalUser = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true),
                    PortalPassword = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true),
                    Latitude = table.Column<float>(type: "float", nullable: false),
                    Longitude = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.StoreUID);
                    table.ForeignKey(
                        name: "FK_Store_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    BuyerEmail = table.Column<string>(type: "text", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    DeliveryMethodId = table.Column<int>(type: "int", nullable: true),
                    Subtotal = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    PaymentIntentId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_DeliveryMethod_DeliveryMethodId",
                        column: x => x.DeliveryMethodId,
                        principalTable: "DeliveryMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageURL = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    StoreUID = table.Column<string>(type: "char(38)", maxLength: 38, nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Store_StoreUID",
                        column: x => x.StoreUID,
                        principalTable: "Store",
                        principalColumn: "StoreUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreRecipient",
                columns: table => new
                {
                    StoreRecipientUID = table.Column<string>(type: "char(38)", maxLength: 38, nullable: false),
                    StoreUID = table.Column<string>(type: "char(38)", maxLength: 38, nullable: true),
                    RecipientUID = table.Column<string>(type: "char(38)", maxLength: 38, nullable: true),
                    EmployeeUID = table.Column<string>(type: "char(38)", maxLength: 38, nullable: true),
                    DateRegistered = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreRecipient", x => x.StoreRecipientUID);
                    table.ForeignKey(
                        name: "FK_StoreRecipient_Recipient_RecipientUID",
                        column: x => x.RecipientUID,
                        principalTable: "Recipient",
                        principalColumn: "RecipientUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreRecipient_Store_StoreUID",
                        column: x => x.StoreUID,
                        principalTable: "Store",
                        principalColumn: "StoreUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "text", nullable: true),
                    ZipCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Address_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Token",
                columns: table => new
                {
                    TokenUID = table.Column<string>(type: "char(38)", maxLength: 38, nullable: false),
                    TokenName = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    DonatorUID = table.Column<string>(type: "char(38)", maxLength: 38, nullable: true),
                    StoreUID = table.Column<string>(type: "char(38)", maxLength: 38, nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    StoreMealUID = table.Column<string>(type: "char(38)", maxLength: 38, nullable: true),
                    RecipientUID = table.Column<string>(type: "char(38)", maxLength: 38, nullable: true),
                    CostPrice = table.Column<float>(type: "float", nullable: false),
                    SalesPrice = table.Column<float>(type: "float", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateStoreAssigned = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateAssigned = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateCollected = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateRelease = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateExpire = table.Column<DateTime>(type: "datetime", nullable: false),
                    FoodCollected = table.Column<ulong>(type: "bit", nullable: false),
                    Valid = table.Column<ulong>(type: "bit", nullable: false),
                    ImageURL = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    ShortURL = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    RecipientName = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    DonatorName = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Token", x => x.TokenUID);
                    table.ForeignKey(
                        name: "FK_Token_Donator_DonatorUID",
                        column: x => x.DonatorUID,
                        principalTable: "Donator",
                        principalColumn: "DonatorUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Token_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Token_Recipient_RecipientUID",
                        column: x => x.RecipientUID,
                        principalTable: "Recipient",
                        principalColumn: "RecipientUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Token_Store_StoreUID",
                        column: x => x.StoreUID,
                        principalTable: "Store",
                        principalColumn: "StoreUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DonatorUID = table.Column<string>(type: "char(38)", maxLength: 38, nullable: true),
                    StoreUID = table.Column<string>(type: "char(38)", maxLength: 38, nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    EmployeeUID = table.Column<string>(type: "char(38)", maxLength: 38, nullable: true),
                    CostPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DatePurchased = table.Column<DateTime>(type: "datetime", nullable: false),
                    MealsPerWeek = table.Column<int>(type: "int", nullable: false),
                    MealsPerMonth = table.Column<int>(type: "int", nullable: false),
                    Recurring = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_Donator_DonatorUID",
                        column: x => x.DonatorUID,
                        principalTable: "Donator",
                        principalColumn: "DonatorUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaction_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaction_Store_StoreUID",
                        column: x => x.StoreUID,
                        principalTable: "Store",
                        principalColumn: "StoreUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductItemOrdered",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false),
                    ProductItemId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "text", nullable: true),
                    ImageURL = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItemOrdered", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_ProductItemOrdered_OrderItem_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donator_CountryId",
                table: "Donator",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CountryId",
                table: "Employee",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_DeliveryMethodId",
                table: "Order",
                column: "DeliveryMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductTypeId",
                table: "Product",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_StoreUID",
                table: "Product",
                column: "StoreUID");

            migrationBuilder.CreateIndex(
                name: "IX_Recipient_CountryId",
                table: "Recipient",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Store_CountryId",
                table: "Store",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreRecipient_RecipientUID",
                table: "StoreRecipient",
                column: "RecipientUID");

            migrationBuilder.CreateIndex(
                name: "IX_StoreRecipient_StoreUID",
                table: "StoreRecipient",
                column: "StoreUID");

            migrationBuilder.CreateIndex(
                name: "IX_Token_DonatorUID",
                table: "Token",
                column: "DonatorUID");

            migrationBuilder.CreateIndex(
                name: "IX_Token_ProductId",
                table: "Token",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Token_RecipientUID",
                table: "Token",
                column: "RecipientUID");

            migrationBuilder.CreateIndex(
                name: "IX_Token_StoreUID",
                table: "Token",
                column: "StoreUID");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_DonatorUID",
                table: "Transaction",
                column: "DonatorUID");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_ProductId",
                table: "Transaction",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_StoreUID",
                table: "Transaction",
                column: "StoreUID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "ProductItemOrdered");

            migrationBuilder.DropTable(
                name: "StoreRecipient");

            migrationBuilder.DropTable(
                name: "Token");

            migrationBuilder.DropTable(
                name: "TokenMessage");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Recipient");

            migrationBuilder.DropTable(
                name: "Donator");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "DeliveryMethod");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}