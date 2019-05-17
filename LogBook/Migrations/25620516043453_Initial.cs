using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LogBook.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    HN = table.Column<string>(maxLength: 8, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    Sex = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.HN);
                });

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    AN = table.Column<string>(maxLength: 10, nullable: false),
                    AdmissionDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PatientHN = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.AN);
                    table.ForeignKey(
                        name: "FK_Visits_Patients_PatientHN",
                        column: x => x.PatientHN,
                        principalTable: "Patients",
                        principalColumn: "HN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DivisionVisits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DivisionName = table.Column<string>(maxLength: 30, nullable: false),
                    UserName = table.Column<string>(maxLength: 30, nullable: false),
                    VisitAN = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    DateFollowUp = table.Column<DateTime>(nullable: true),
                    MissFollowUp = table.Column<int>(nullable: true),
                    IsINRInTarget = table.Column<int>(nullable: true),
                    WardName = table.Column<string>(nullable: true),
                    WardTimeArrive = table.Column<DateTime>(nullable: true),
                    Diagnosis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivisionVisits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DivisionVisits_Visits_VisitAN",
                        column: x => x.VisitAN,
                        principalTable: "Visits",
                        principalColumn: "AN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DivisionVisits_VisitAN",
                table: "DivisionVisits",
                column: "VisitAN");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_PatientHN",
                table: "Visits",
                column: "PatientHN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DivisionVisits");

            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
