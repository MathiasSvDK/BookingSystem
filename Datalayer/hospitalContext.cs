using System;
using System.Collections.Generic;
using Datalayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Datalayer
{
	public partial class hospitalContext : DbContext
	{
		public hospitalContext(DbContextOptions<hospitalContext> options)
			: base(options)
		{
		}

		public virtual DbSet<Employee> Employees { get; set; } = null!;
		public virtual DbSet<Hospital> Hospitals { get; set; } = null!;
		//public virtual DbSet<Patient> Patients { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(255)
                    .HasColumnName("firstname");

                entity.Property(e => e.HospitalId)
                    .HasColumnType("int(11)")
                    .HasColumnName("hospital_id");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(255)
                    .HasColumnName("lastname");

                entity.Property(e => e.Mobilnr)
                    .HasMaxLength(255)
                    .HasColumnName("mobilnr");

                entity.Property(e => e.Role)
                    .HasMaxLength(255)
                    .HasColumnName("role");
            });

            modelBuilder.Entity<Hospital>(entity =>
            {
                entity.ToTable("hospital");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.Beds)
                    .HasColumnType("int(11)")
                    .HasColumnName("beds");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            //modelBuilder.Entity<Patient>(entity =>
            //{
            //    entity.ToTable("patients");

            //    entity.Property(e => e.Id)
            //        .HasColumnType("int(11)")
            //        .HasColumnName("id");

            //    entity.Property(e => e.Address)
            //        .HasMaxLength(255)
            //        .HasColumnName("address");

            //    entity.Property(e => e.Cpr)
            //        .HasMaxLength(255)
            //        .HasColumnName("cpr");

            //    entity.Property(e => e.Firstname)
            //        .HasMaxLength(255)
            //        .HasColumnName("firstname");

            //    entity.Property(e => e.Lastname)
            //        .HasMaxLength(255)
            //        .HasColumnName("lastname");

            //    entity.Property(e => e.Mobilnr)
            //        .HasMaxLength(255)
            //        .HasColumnName("mobilnr");

            //    entity.Property(e => e.Note)
            //        .HasMaxLength(255)
            //        .HasColumnName("note");
            //});

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
