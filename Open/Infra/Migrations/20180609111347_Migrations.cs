using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Open.Infra.Migrations {
    public partial class Migrations : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.CreateTable(
                "Country",
                table => new {
                    ID = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<DateTime>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Country", x => x.ID); });

            migrationBuilder.CreateTable(
                "Currency",
                table => new {
                    ID = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<DateTime>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Currency", x => x.ID); });

            migrationBuilder.CreateTable(
                "Payments",
                table => new {
                    CheckNumber = table.Column<string>(nullable: true),
                    CreditLimit = table.Column<string>(nullable: true),
                    CardAssociationName = table.Column<string>(nullable: true),
                    CardNumber = table.Column<string>(nullable: true),
                    DailyWithDrawalLimit = table.Column<string>(nullable: true),
                    ID = table.Column<string>(nullable: false),
                    Amount = table.Column<string>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Memo = table.Column<string>(nullable: true),
                    Payee = table.Column<string>(nullable: true),
                    PayeeAccountNumber = table.Column<string>(nullable: true),
                    Payer = table.Column<string>(nullable: true),
                    PayerAccountNumber = table.Column<string>(nullable: true),
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<DateTime>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Payments", x => x.ID); });

            migrationBuilder.CreateTable(
                "Address",
                table => new {
                    ID = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    CityOrAreaCode = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    RegionOrStateOrCountryCode = table.Column<string>(nullable: true),
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<DateTime>(nullable: false),
                    ZipOrPostCodeOrExtension = table.Column<string>(nullable: true),
                    CountryID = table.Column<string>(nullable: true),
                    Device = table.Column<int>(nullable: true),
                    NationalDirectDialingPrefix = table.Column<string>(nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Address", x => x.ID);
                    table.ForeignKey(
                        "FK_Address_Country_CountryID",
                        x => x.CountryID,
                        "Country",
                        "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "CountryCurrency",
                table => new {
                    CountryID = table.Column<string>(nullable: false),
                    CurrencyID = table.Column<string>(nullable: false),
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<DateTime>(nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_CountryCurrency", x => new {x.CountryID, x.CurrencyID});
                    table.ForeignKey(
                        "FK_CountryCurrency_Country_CountryID",
                        x => x.CountryID,
                        "Country",
                        "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_CountryCurrency_Currency_CurrencyID",
                        x => x.CurrencyID,
                        "Currency",
                        "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "TelecomDeviceRegistration",
                table => new {
                    AddressID = table.Column<string>(nullable: false),
                    DeviceID = table.Column<string>(nullable: false),
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<DateTime>(nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_TelecomDeviceRegistration", x => new {x.AddressID, x.DeviceID});
                    table.ForeignKey(
                        "FK_TelecomDeviceRegistration_Address_AddressID",
                        x => x.AddressID,
                        "Address",
                        "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_TelecomDeviceRegistration_Address_DeviceID",
                        x => x.DeviceID,
                        "Address",
                        "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_Address_CountryID",
                "Address",
                "CountryID");

            migrationBuilder.CreateIndex(
                "IX_CountryCurrency_CurrencyID",
                "CountryCurrency",
                "CurrencyID");

            migrationBuilder.CreateIndex(
                "IX_TelecomDeviceRegistration_DeviceID",
                "TelecomDeviceRegistration",
                "DeviceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(
                "CountryCurrency");

            migrationBuilder.DropTable(
                "Payments");

            migrationBuilder.DropTable(
                "TelecomDeviceRegistration");

            migrationBuilder.DropTable(
                "Currency");

            migrationBuilder.DropTable(
                "Address");

            migrationBuilder.DropTable(
                "Country");
        }
    }
}