using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VCMS.EF.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Diagnostics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VARCHAR = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnostics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    YearGraduated = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TradeName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    GenericName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    Category = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Unit = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    UnitInStock = table.Column<int>(type: "int", nullable: false),
                    CostPricePerItem = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    SalePricePerItem = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    ExpirationDate = table.Column<DateOnly>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    SpeciesId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<byte>(type: "TINYINT", nullable: false),
                    Age = table.Column<string>(type: "VARCHAR(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patients_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    DiagnosisId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<byte>(type: "TINYINT", nullable: false),
                    CaseType = table.Column<byte>(type: "TINYINT", nullable: false),
                    Date = table.Column<DateOnly>(type: "DATE", nullable: false),
                    Notes = table.Column<string>(type: "VARCHAR(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cases_Diagnostics_DiagnosisId",
                        column: x => x.DiagnosisId,
                        principalTable: "Diagnostics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cases_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cases_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateOnly>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrescribedMeds",
                columns: table => new
                {
                    PrescriptionId = table.Column<int>(type: "int", nullable: false),
                    MedicationId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false, computedColumnSql: "Quantity * Price"),
                    Frequency = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescribedMeds", x => new { x.PrescriptionId, x.MedicationId });
                    table.ForeignKey(
                        name: "FK_PrescribedMeds_Medications_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrescribedMeds_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescriptionId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateOnly>(type: "DATE", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receipts_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Address", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Tahway - Uomo Street", "Mohamed", "Badwy", "01553414588" },
                    { 2, "Tahway - Uomo Street", "Elsaid", "Badwy", "01063090820" },
                    { 3, "Tahway - Saafna Street", "Mazen", "Fatouha", "01036547892" },
                    { 4, "Tahway - Saafna Street", "Hazem", "Fatouha", "01036564892" },
                    { 5, "Tahway - Saafna Street", "Fatouha", "Ekaref", "01366564892" }
                });

            migrationBuilder.InsertData(
                table: "Diagnostics",
                columns: new[] { "Id", "VARCHAR" },
                values: new object[,]
                {
                    { 1, "Head Lice" },
                    { 2, "Onchocerciasis" },
                    { 3, "Strongyloidiasis" },
                    { 4, "Ascariasis" },
                    { 5, "Trichuriasis" },
                    { 6, "Enterobiasis" },
                    { 7, "Antiparasitic" },
                    { 8, "Liver Fluke" },
                    { 9, "External Parasites" },
                    { 10, "Lung Worms" },
                    { 11, "Gastrointestinal Roundworms" },
                    { 12, "Coccidiosis" },
                    { 13, "Avian Influenza" },
                    { 14, "Intestinal Diarrhea" },
                    { 15, "Protection" },
                    { 16, "Wounds" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNumber", "YearGraduated" },
                values: new object[] { 1, "badwyelsaid@gmail.com", "Badwy", "Elsaid", "01112516588", 1990 });

            migrationBuilder.InsertData(
                table: "Medications",
                columns: new[] { "Id", "Category", "CostPricePerItem", "ExpirationDate", "GenericName", "SalePricePerItem", "TradeName", "Unit", "UnitInStock" },
                values: new object[,]
                {
                    { 1, "Semi-Synthetic Antiparasitic", 500m, new DateOnly(2027, 1, 1), "Ivomec", 550m, "Ivomaac Super", "50 ml", 20 },
                    { 2, "Semi-Synthetic Antiparasitic", 45m, new DateOnly(2026, 1, 1), "Ivermectin", 70m, "Ivomaac Normal", "50 ml", 30 },
                    { 3, "Semi-Synthetic Antiparasitic, Liver Fluke", 80m, new DateOnly(2027, 6, 1), "Dictomec", 120m, "Ivomaac Super", "50 ml", 30 },
                    { 4, "Semi-Synthetic Antiparasitic, Liver Fluke", 45m, new DateOnly(2025, 6, 1), "Venomectin S", 100m, "Ivomaac Super", "50 ml", 15 },
                    { 5, "Stimulation of the Metabolism", 45m, new DateOnly(2026, 2, 26), "Vetazal", 80m, "Stimulating", "100 ml", 10 },
                    { 6, "Antibiotic", 40m, new DateOnly(2025, 12, 30), "Oxytetracycline 20%", 60m, "Antibiotic", "30 ml", 10 },
                    { 7, "Penicillin", 25m, new DateOnly(2026, 5, 1), "Vetrocin", 35m, "Penicillin", "8 gm", 25 },
                    { 8, "Anticoccidial", 25m, new DateOnly(2026, 1, 1), "Clazox", 50m, "Anticoccidial", "100 ml", 30 },
                    { 9, "Antitoxin - Antifungal", 10m, new DateOnly(2028, 1, 1), "Sendex", 15m, "Antitoxin - Antifungal", "100 ml", 100 },
                    { 10, "Antibiotic", 10m, new DateOnly(2028, 3, 1), "Oxytetracycline 20%", 15m, "Antibiotic", "20 gm", 30 },
                    { 11, "Antibiotic", 20m, new DateOnly(2028, 3, 1), "New Oxy", 24m, "Antibiotic", "8 Tablets in Two Strips", 100 },
                    { 12, "Vitamins", 7m, new DateOnly(2028, 3, 1), "Vitamid", 10m, "Vitamins", "20 gm", 100 },
                    { 13, "Vitamins", 5m, new DateOnly(2028, 3, 1), "AD3H", 7.5m, "Vitamins", "100 ml", 200 },
                    { 14, "Calcium", 5m, new DateOnly(2028, 3, 1), "Pure Phose", 7.5m, "Calcium", "100 ml", 300 },
                    { 15, "Intestinal Diarrhea - Protection", 2.1m, new DateOnly(2027, 3, 1), "Cloromophincol", 5m, "Antibiotic", "100 ml", 120 },
                    { 16, "Intestinal Diarrhea - Protection", 2.1m, new DateOnly(2027, 3, 1), "Newvit", 5m, "Antibiotic", "100 ml", 120 },
                    { 17, "Protection", 2.1m, new DateOnly(2027, 3, 1), "Oxy 1 2 3", 5m, "Antibiotic", "100 ml", 120 }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cattle" },
                    { 2, "Horse" },
                    { 3, "Sheep" },
                    { 4, "Goat" },
                    { 5, "Pig" },
                    { 6, "Geese" },
                    { 7, "Chicken" },
                    { 8, "Duck" },
                    { 9, "Pigeon" },
                    { 10, "Dog" },
                    { 11, "Cat" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Age", "ClientId", "Count", "Sex", "SpeciesId" },
                values: new object[,]
                {
                    { 1, "15 Days", 1, 10, (byte)0, 6 },
                    { 2, "20 Days", 2, 15, (byte)0, 8 },
                    { 3, "6 Months", 3, 1, (byte)0, 11 },
                    { 4, "2 Years and One Month", 4, 1, (byte)0, 2 },
                    { 5, "1 Year and Two Months", 5, 2, (byte)0, 1 }
                });

            migrationBuilder.InsertData(
                table: "Cases",
                columns: new[] { "Id", "CaseType", "Date", "DiagnosisId", "DoctorId", "Notes", "PatientId", "Status" },
                values: new object[,]
                {
                    { 1, (byte)0, new DateOnly(2023, 1, 1), 12, 1, "Take them away from ducks.", 1, (byte)0 },
                    { 2, (byte)0, new DateOnly(2023, 1, 2), 14, 1, "Take them away from chicken.", 2, (byte)0 },
                    { 3, (byte)0, new DateOnly(2023, 1, 3), 7, 1, "Take them the water with medication before eating.", 3, (byte)0 },
                    { 4, (byte)1, new DateOnly(2023, 1, 4), 16, 1, "Dont't begin work after one month", 4, (byte)0 },
                    { 5, (byte)0, new DateOnly(2023, 1, 5), 2, 1, null, 5, (byte)0 },
                    { 6, (byte)0, new DateOnly(2023, 2, 15), 15, 1, null, 2, (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "Id", "CaseId", "Date" },
                values: new object[,]
                {
                    { 1, 1, new DateOnly(2023, 1, 1) },
                    { 2, 2, new DateOnly(2023, 1, 2) },
                    { 3, 3, new DateOnly(2023, 1, 3) },
                    { 4, 4, new DateOnly(2023, 1, 4) },
                    { 5, 5, new DateOnly(2023, 1, 5) },
                    { 6, 6, new DateOnly(2023, 1, 15) }
                });

            migrationBuilder.InsertData(
                table: "PrescribedMeds",
                columns: new[] { "MedicationId", "PrescriptionId", "Frequency", "Price", "Quantity" },
                values: new object[,]
                {
                    { 8, 1, "1 ml for 1 litre.", 50m, 2 },
                    { 11, 1, "1 tablet for 4 litre.", 24m, 2 },
                    { 15, 2, "1 gm for 1 litre.", 5m, 2 },
                    { 16, 2, "1 gm for 1 litre.", 5m, 2 },
                    { 4, 3, "1 ml for 50 kg.", 100m, 1 },
                    { 6, 4, "1 ml for 50 kg.", 60m, 2 },
                    { 7, 4, "1 ml for 50 kg.", 35m, 3 },
                    { 4, 5, "1 ml for 50 kg.", 100m, 1 },
                    { 12, 6, "1 gm for 1 litre.", 10m, 3 },
                    { 13, 6, "2 ml for 1 litre.", 7.5m, 3 },
                    { 14, 6, "2 ml for 1 litre.", 7.5m, 3 },
                    { 16, 6, "1 gm for 1 litre.", 5m, 3 },
                    { 17, 6, "1 gm for 1 litre.", 5m, 3 }
                });

            migrationBuilder.InsertData(
                table: "Receipts",
                columns: new[] { "Id", "Date", "PrescriptionId", "TotalPrice" },
                values: new object[,]
                {
                    { 1, new DateOnly(2023, 1, 1), 1, 148m },
                    { 2, new DateOnly(2023, 1, 2), 2, 20m },
                    { 3, new DateOnly(2023, 1, 3), 3, 100m },
                    { 4, new DateOnly(2023, 1, 4), 4, 225m },
                    { 5, new DateOnly(2023, 1, 5), 5, 100m },
                    { 6, new DateOnly(2023, 1, 15), 6, 105m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cases_DiagnosisId",
                table: "Cases",
                column: "DiagnosisId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_DoctorId",
                table: "Cases",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_PatientId",
                table: "Cases",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_ClientId",
                table: "Patients",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_SpeciesId",
                table: "Patients",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescribedMeds_MedicationId",
                table: "PrescribedMeds",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescribedMeds_PrescriptionId_MedicationId",
                table: "PrescribedMeds",
                columns: new[] { "PrescriptionId", "MedicationId" });

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_CaseId",
                table: "Prescriptions",
                column: "CaseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_PrescriptionId",
                table: "Receipts",
                column: "PrescriptionId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrescribedMeds");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropTable(
                name: "Medications");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "Diagnostics");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Species");
        }
    }
}
