﻿// <auto-generated />
using System;
using Datalayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Datalayer.Migrations
{
    [DbContext(typeof(BookingContext))]
    partial class BookingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Datalayer.Entities.Available", b =>
                {
                    b.Property<int>("AvailableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsTaken")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("AvailableId");

                    b.ToTable("Availables");
                });

            modelBuilder.Entity("Datalayer.Entities.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AvailableId")
                        .HasColumnType("int");

                    b.Property<int>("HospitalId")
                        .HasColumnType("int");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("PatientId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TreatmentId")
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.HasIndex("AvailableId")
                        .IsUnique();

                    b.HasIndex("TreatmentId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Datalayer.Entities.Hospitalization", b =>
                {
                    b.Property<int>("HospitalizationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("HospitalId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDischarged")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("TimeOfDischarged")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("TimeOfHospitalized")
                        .HasColumnType("datetime(6)");

                    b.HasKey("HospitalizationID");

                    b.ToTable("Hospitalization");
                });

            modelBuilder.Entity("Datalayer.Entities.Treatment", b =>
                {
                    b.Property<int>("TreatmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TreatmentName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("TreatmentId");

                    b.ToTable("Treatments");

                    b.HasData(
                        new
                        {
                            TreatmentId = 1,
                            Description = "Blodprøver er blod udtaget fra en vene, som er de blodårer, der fører tilbage til hjertet. Blodet kan undersøges for sammensætning af salte, enzymer og proteiner, og i et vist omfang genetisk materiale. ",
                            TreatmentName = "Blodprøve"
                        });
                });

            modelBuilder.Entity("Datalayer.Entities.Booking", b =>
                {
                    b.HasOne("Datalayer.Entities.Available", "Available")
                        .WithOne("Booking")
                        .HasForeignKey("Datalayer.Entities.Booking", "AvailableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Datalayer.Entities.Treatment", "Treatment")
                        .WithMany("Bookings")
                        .HasForeignKey("TreatmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Available");

                    b.Navigation("Treatment");
                });

            modelBuilder.Entity("Datalayer.Entities.Available", b =>
                {
                    b.Navigation("Booking");
                });

            modelBuilder.Entity("Datalayer.Entities.Treatment", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
