using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VCMS.EF.Migrations
{
    /// <inheritdoc />
    public partial class InsertInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { 1, "Semi-Synthetic Antiparasitic", 500m, new DateTime(2027, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ivomec", 550m, "Ivomaac Super", "50 ml", 20 },
                    { 2, "Semi-Synthetic Antiparasitic", 45m, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ivermectin", 70m, "Ivomaac Normal", "50 ml", 30 },
                    { 3, "Semi-Synthetic Antiparasitic, Liver Fluke", 80m, new DateTime(2027, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dictomec", 120m, "Ivomaac Super", "50 ml", 30 },
                    { 4, "Semi-Synthetic Antiparasitic, Liver Fluke", 45m, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Venomectin S", 100m, "Ivomaac Super", "50 ml", 15 },
                    { 5, "Stimulation of the Metabolism", 45m, new DateTime(2026, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vetazal", 80m, "Stimulating", "100 ml", 10 },
                    { 6, "Antibiotic", 40m, new DateTime(2025, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oxytetracycline 20%", 60m, "Antibiotic", "30 ml", 10 },
                    { 7, "Penicillin", 25m, new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vetrocin", 35m, "Penicillin", "8 gm", 25 },
                    { 8, "Anticoccidial", 25m, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clazox", 50m, "Anticoccidial", "100 ml", 30 },
                    { 9, "Antitoxin - Antifungal", 10m, new DateTime(2028, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sendex", 15m, "Antitoxin - Antifungal", "100 ml", 100 },
                    { 10, "Antibiotic", 10m, new DateTime(2028, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oxytetracycline 20%", 15m, "Antibiotic", "20 gm", 30 },
                    { 11, "Antibiotic", 20m, new DateTime(2028, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Oxy", 24m, "Antibiotic", "8 Tablets in Two Strips", 100 },
                    { 12, "Vitamins", 7m, new DateTime(2028, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vitamid", 10m, "Vitamins", "20 gm", 100 },
                    { 13, "Vitamins", 5m, new DateTime(2028, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AD3H", 7.5m, "Vitamins", "100 ml", 200 },
                    { 14, "Calcium", 5m, new DateTime(2028, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pure Phose", 7.5m, "Calcium", "100 ml", 300 },
                    { 15, "Intestinal Diarrhea - Protection", 2.1m, new DateTime(2027, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cloromophincol", 5m, "Antibiotic", "100 ml", 120 },
                    { 16, "Intestinal Diarrhea - Protection", 2.1m, new DateTime(2027, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Newvit", 5m, "Antibiotic", "100 ml", 120 },
                    { 17, "Protection", 2.1m, new DateTime(2027, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oxy 1 2 3", 5m, "Antibiotic", "100 ml", 120 }
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
                    { 1, (byte)0, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 1, "Take them away from ducks.", 1, (byte)0 },
                    { 2, (byte)0, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 1, "Take them away from chicken.", 2, (byte)0 },
                    { 3, (byte)0, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1, "Take them the water with medication before eating.", 3, (byte)0 },
                    { 4, (byte)1, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, 1, "Dont't begin work after one month", 4, (byte)0 },
                    { 5, (byte)0, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, null, 5, (byte)0 },
                    { 6, (byte)0, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 1, null, 2, (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "Id", "CaseId", "Date" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 6, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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
                    { 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 148m },
                    { 2, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 20m },
                    { 3, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 100m },
                    { 4, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 225m },
                    { 5, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 100m },
                    { 6, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 105m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Diagnostics",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Diagnostics",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Diagnostics",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Diagnostics",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Diagnostics",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Diagnostics",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Diagnostics",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Diagnostics",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Diagnostics",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Diagnostics",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PrescribedMeds",
                keyColumns: new[] { "MedicationId", "PrescriptionId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "PrescribedMeds",
                keyColumns: new[] { "MedicationId", "PrescriptionId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "PrescribedMeds",
                keyColumns: new[] { "MedicationId", "PrescriptionId" },
                keyValues: new object[] { 15, 2 });

            migrationBuilder.DeleteData(
                table: "PrescribedMeds",
                keyColumns: new[] { "MedicationId", "PrescriptionId" },
                keyValues: new object[] { 16, 2 });

            migrationBuilder.DeleteData(
                table: "PrescribedMeds",
                keyColumns: new[] { "MedicationId", "PrescriptionId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "PrescribedMeds",
                keyColumns: new[] { "MedicationId", "PrescriptionId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "PrescribedMeds",
                keyColumns: new[] { "MedicationId", "PrescriptionId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "PrescribedMeds",
                keyColumns: new[] { "MedicationId", "PrescriptionId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "PrescribedMeds",
                keyColumns: new[] { "MedicationId", "PrescriptionId" },
                keyValues: new object[] { 12, 6 });

            migrationBuilder.DeleteData(
                table: "PrescribedMeds",
                keyColumns: new[] { "MedicationId", "PrescriptionId" },
                keyValues: new object[] { 13, 6 });

            migrationBuilder.DeleteData(
                table: "PrescribedMeds",
                keyColumns: new[] { "MedicationId", "PrescriptionId" },
                keyValues: new object[] { 14, 6 });

            migrationBuilder.DeleteData(
                table: "PrescribedMeds",
                keyColumns: new[] { "MedicationId", "PrescriptionId" },
                keyValues: new object[] { 16, 6 });

            migrationBuilder.DeleteData(
                table: "PrescribedMeds",
                keyColumns: new[] { "MedicationId", "PrescriptionId" },
                keyValues: new object[] { 17, 6 });

            migrationBuilder.DeleteData(
                table: "Receipts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Receipts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Receipts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Receipts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Receipts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Receipts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cases",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cases",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cases",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cases",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cases",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cases",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Diagnostics",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Diagnostics",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Diagnostics",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Diagnostics",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Diagnostics",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Diagnostics",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 11);
        }
    }
}
