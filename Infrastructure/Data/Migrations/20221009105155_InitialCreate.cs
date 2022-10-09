using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Donator",
                columns: table => new
                {
                    DonatorUID = table.Column<string>(type: "char(38)", maxLength: 38, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    Surname = table.Column<string>(type: "TEXT", nullable: true),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Nickname = table.Column<string>(type: "TEXT", nullable: true),
                    MobileNumber = table.Column<string>(type: "TEXT", nullable: true),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Address2 = table.Column<string>(type: "TEXT", nullable: true),
                    Suburb = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: true),
                    CountryId = table.Column<int>(type: "INTEGER", nullable: false),
                    DefaultToken = table.Column<string>(type: "TEXT", nullable: true),
                    PortalUser = table.Column<string>(type: "TEXT", nullable: true),
                    PortalPassword = table.Column<string>(type: "TEXT", nullable: true),
                    Latitude = table.Column<double>(type: "REAL", nullable: false),
                    Longitude = table.Column<double>(type: "REAL", nullable: false),
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
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    Surname = table.Column<string>(type: "TEXT", nullable: true),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Nickname = table.Column<string>(type: "TEXT", nullable: true),
                    MobileNumber = table.Column<string>(type: "TEXT", nullable: true),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Address2 = table.Column<string>(type: "TEXT", nullable: true),
                    Suburb = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: true),
                    CountryId = table.Column<int>(type: "INTEGER", nullable: false),
                    DefaultToken = table.Column<string>(type: "TEXT", nullable: true),
                    PortalUser = table.Column<string>(type: "TEXT", nullable: true),
                    PortalPassword = table.Column<string>(type: "TEXT", nullable: true),
                    Latitude = table.Column<double>(type: "REAL", nullable: false),
                    Longitude = table.Column<double>(type: "REAL", nullable: false)
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
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    Surname = table.Column<string>(type: "TEXT", nullable: true),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Nickname = table.Column<string>(type: "TEXT", nullable: true),
                    MobileNumber = table.Column<string>(type: "TEXT", nullable: true),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Address2 = table.Column<string>(type: "TEXT", nullable: true),
                    Suburb = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: true),
                    CountryId = table.Column<int>(type: "INTEGER", nullable: false),
                    DefaultToken = table.Column<string>(type: "TEXT", nullable: true),
                    PortalUser = table.Column<string>(type: "TEXT", nullable: true),
                    PortalPassword = table.Column<string>(type: "TEXT", nullable: true),
                    Latitude = table.Column<double>(type: "REAL", nullable: false),
                    Longitude = table.Column<double>(type: "REAL", nullable: false),
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
                    StoreName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    Surname = table.Column<string>(type: "TEXT", nullable: true),
                    FullName = table.Column<string>(type: "TEXT", nullable: true),
                    Nickname = table.Column<string>(type: "TEXT", nullable: true),
                    MobileNumber = table.Column<string>(type: "TEXT", nullable: true),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Address2 = table.Column<string>(type: "TEXT", nullable: true),
                    Suburb = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: true),
                    CountryId = table.Column<int>(type: "INTEGER", nullable: false),
                    DefaultToken = table.Column<string>(type: "TEXT", nullable: true),
                    PortalUser = table.Column<string>(type: "TEXT", nullable: true),
                    PortalPassword = table.Column<string>(type: "TEXT", nullable: true),
                    Latitude = table.Column<double>(type: "REAL", nullable: false),
                    Longitude = table.Column<double>(type: "REAL", nullable: false)
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
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    ProductTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    StoreUID = table.Column<string>(type: "char(38)", maxLength: 38, nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
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
                    DateRegistered = table.Column<DateTime>(type: "TEXT", nullable: false)
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
                name: "Token",
                columns: table => new
                {
                    TokenUID = table.Column<string>(type: "char(38)", maxLength: 38, nullable: false),
                    TokenName = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    DonatorUID = table.Column<string>(type: "char(38)", maxLength: 38, nullable: true),
                    BuyerEmail = table.Column<string>(type: "TEXT", nullable: true),
                    AppUserId = table.Column<string>(type: "TEXT", nullable: true),
                    StoreUID = table.Column<string>(type: "char(38)", maxLength: 38, nullable: true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    StoreMealUID = table.Column<string>(type: "char(38)", maxLength: 38, nullable: true),
                    RecipientUID = table.Column<string>(type: "char(38)", maxLength: 38, nullable: true),
                    CostPrice = table.Column<double>(type: "decimal(18,2)", nullable: false),
                    SalesPrice = table.Column<double>(type: "decimal(18,2)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateStoreAssigned = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateAssigned = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateCollected = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateRelease = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateExpire = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FoodCollected = table.Column<bool>(type: "INTEGER", nullable: false),
                    Valid = table.Column<bool>(type: "INTEGER", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    ShortUrl = table.Column<string>(type: "TEXT", nullable: true),
                    RecipientName = table.Column<string>(type: "TEXT", nullable: true),
                    DonatorName = table.Column<string>(type: "TEXT", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_Donator_CountryId",
                table: "Donator",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CountryId",
                table: "Employee",
                column: "CountryId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "StoreRecipient");

            migrationBuilder.DropTable(
                name: "Token");

            migrationBuilder.DropTable(
                name: "Donator");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Recipient");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
