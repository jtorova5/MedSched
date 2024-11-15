using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedSched.Migrations
{
    /// <inheritdoc />
    public partial class seeding_db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "doctors",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    specialization = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    availability = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctors", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    birthdate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    contact_number = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    appointment_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    patient_id = table.Column<int>(type: "int", nullable: false),
                    doctor_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => x.id);
                    table.ForeignKey(
                        name: "FK_appointments_doctors_doctor_id",
                        column: x => x.doctor_id,
                        principalTable: "doctors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointments_patients_patient_id",
                        column: x => x.patient_id,
                        principalTable: "patients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "id", "availability", "email", "name", "password", "specialization" },
                values: new object[,]
                {
                    { 1, true, "doc1@example.com", "Dr. John Doe", "123", "Cardiologist" },
                    { 2, true, "doc2@example.com", "Dr. Jane Smith", "123", "Neurologist" },
                    { 3, false, "doc3@example.com", "Dr. Emily Brown", "123", "Dermatologist" },
                    { 4, true, "doc4@example.com", "Dr. Michael Johnson", "123", "Orthopedist" },
                    { 5, true, "doc5@example.com", "Dr. Sarah Lee", "123", "Pediatrician" },
                    { 6, true, "doc6@example.com", "Dr. Robert White", "123", "General Surgeon" },
                    { 7, true, "doc7@example.com", "Dr. Olivia Harris", "123", "Psychiatrist" },
                    { 8, false, "doc8@example.com", "Dr. William Clark", "123", "Gastroenterologist" },
                    { 9, true, "doc9@example.com", "Dr. Patricia Lewis", "123", "Gynecologist" },
                    { 10, true, "doc10@example.com", "Dr. James Walker", "123", "Anesthesiologist" }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "id", "birthdate", "contact_number", "email", "name", "password" },
                values: new object[,]
                {
                    { 1, new DateTime(1985, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "555-1234", "user1@example.com", "John Doe", "123" },
                    { 2, new DateTime(1990, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "555-5678", "user2@example.com", "Jane Smith", "123" },
                    { 3, new DateTime(1979, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "555-8765", "user3@example.com", "Emily Johnson", "123" },
                    { 4, new DateTime(2000, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "555-4321", "user4@example.com", "Michael Brown", "123" },
                    { 5, new DateTime(1988, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "555-8763", "user5@example.com", "Sarah Lee", "123" },
                    { 6, new DateTime(1995, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "555-1029", "user6@example.com", "Robert White", "123" },
                    { 7, new DateTime(1982, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "555-3245", "user7@example.com", "Olivia Harris", "123" },
                    { 8, new DateTime(1993, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "555-6543", "user8@example.com", "William Clark", "123" },
                    { 9, new DateTime(1991, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "555-2345", "user9@example.com", "Patricia Lewis", "123" },
                    { 10, new DateTime(1980, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "555-4329", "user10@example.com", "James Walker", "123" }
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "id", "appointment_date", "doctor_id", "patient_id", "status" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Scheduled" },
                    { 2, new DateTime(2024, 11, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "Scheduled" },
                    { 3, new DateTime(2024, 11, 22, 11, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, "Scheduled" },
                    { 4, new DateTime(2024, 11, 23, 14, 30, 0, 0, DateTimeKind.Unspecified), 3, 4, "Completed" },
                    { 5, new DateTime(2024, 11, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), 2, 5, "Scheduled" },
                    { 6, new DateTime(2024, 11, 25, 16, 0, 0, 0, DateTimeKind.Unspecified), 1, 6, "Scheduled" },
                    { 7, new DateTime(2024, 11, 26, 9, 30, 0, 0, DateTimeKind.Unspecified), 3, 7, "Scheduled" },
                    { 8, new DateTime(2024, 11, 27, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 8, "Completed" },
                    { 9, new DateTime(2024, 11, 28, 13, 30, 0, 0, DateTimeKind.Unspecified), 1, 9, "Scheduled" },
                    { 10, new DateTime(2024, 11, 29, 8, 30, 0, 0, DateTimeKind.Unspecified), 3, 10, "Canceled" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_doctor_id",
                table: "appointments",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_patient_id",
                table: "appointments",
                column: "patient_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.DropTable(
                name: "patients");
        }
    }
}
