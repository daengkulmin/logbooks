﻿// <auto-generated />
using System;
using LogBook.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LogBook.Migrations
{
    [DbContext(typeof(AppDb))]
    [Migration("25620516043453_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LogBook.Models.DivisionVisit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("DivisionName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<DateTime?>("LastModifiedDate");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("VisitAN")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("VisitAN");

                    b.ToTable("DivisionVisits");

                    b.HasDiscriminator<string>("Discriminator").HasValue("DivisionVisit");
                });

            modelBuilder.Entity("LogBook.Models.Patient", b =>
                {
                    b.Property<string>("HN")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(8);

                    b.Property<DateTime>("Birthdate");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Phone");

                    b.Property<int>("Sex");

                    b.HasKey("HN");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("LogBook.Models.Visit", b =>
                {
                    b.Property<string>("AN")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10);

                    b.Property<DateTime>("AdmissionDate");

                    b.Property<string>("Description");

                    b.Property<string>("PatientHN")
                        .IsRequired();

                    b.HasKey("AN");

                    b.HasIndex("PatientHN");

                    b.ToTable("Visits");
                });

            modelBuilder.Entity("LogBook.Models.OpdDivisionVisit", b =>
                {
                    b.HasBaseType("LogBook.Models.DivisionVisit");

                    b.Property<DateTime>("DateFollowUp");

                    b.Property<int>("IsINRInTarget");

                    b.Property<int>("MissFollowUp");

                    b.HasDiscriminator().HasValue("OpdDivisionVisit");
                });

            modelBuilder.Entity("LogBook.Models.WardPreDivisionVisit", b =>
                {
                    b.HasBaseType("LogBook.Models.DivisionVisit");

                    b.Property<string>("Diagnosis");

                    b.Property<string>("WardName");

                    b.Property<DateTime>("WardTimeArrive");

                    b.HasDiscriminator().HasValue("WardPreDivisionVisit");
                });

            modelBuilder.Entity("LogBook.Models.DivisionVisit", b =>
                {
                    b.HasOne("LogBook.Models.Visit", "Visit")
                        .WithMany("DivisionVisits")
                        .HasForeignKey("VisitAN")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LogBook.Models.Visit", b =>
                {
                    b.HasOne("LogBook.Models.Patient", "Patient")
                        .WithMany("Visits")
                        .HasForeignKey("PatientHN")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
