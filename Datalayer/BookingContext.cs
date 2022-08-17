using Datalayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Datalayer
{
	public class BookingContext : DbContext
	{
		public BookingContext(DbContextOptions<BookingContext> options)
		   : base(options)
		{
		}

		public DbSet<Booking> Bookings { get; set; }
		public DbSet<Treatment> Treatments { get; set; }
		public DbSet<Available> Availables { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Treatment>().HasData(
			   new Treatment { TreatmentId = 1, TreatmentName = "Blodprøve", Description = "Blodprøver er blod udtaget fra en vene, som er de blodårer, der fører tilbage til hjertet. Blodet kan undersøges for sammensætning af salte, enzymer og proteiner, og i et vist omfang genetisk materiale. " }
			   );

			modelBuilder.Entity<Available>().HasData(
			   new Available { AvailableId = 1, Date = DateTime.Now , IsTaken = true}
			   );

			modelBuilder.Entity<Booking>().HasData(
			   new Booking { BookingId = 1, TreatmentId = 1, AvailableId = 1, PatientId = 1, HospitalId = 1, Reason = "Check up" }
			   );
		}

	}
}