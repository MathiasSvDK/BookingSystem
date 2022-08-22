using System;
using System.Collections.Generic;
using Datalayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Datalayer
{
	public partial class hospitalContext : DbContext
	{
		public hospitalContext(DbContextOptions<hospitalContext> options)
			: base(options)
		{
		}

		//public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;
		public virtual DbSet<Hospital> Hospitals { get; set; } = null!;
		//public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.UseCollation("utf8mb4_general_ci")
				.HasCharSet("utf8mb4");


			modelBuilder.Entity<Hospital>(entity =>
			{
				entity.ToTable("hospital");

				entity.HasIndex(e => e.Name, "name");

				entity.Property(e => e.Id)
					.HasColumnType("int(11)")
					.HasColumnName("id");

				entity.Property(e => e.Address)
					.HasMaxLength(255)
					.HasColumnName("address");

				entity.Property(e => e.Beds)
					.HasColumnType("int(11)")
					.HasColumnName("beds");

				entity.Property(e => e.Name).HasColumnName("name");
			});


			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
