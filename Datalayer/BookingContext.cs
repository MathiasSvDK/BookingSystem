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
		public DbSet<Hospitalization> Hospitalization { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Treatment>().HasData(
			   new Treatment { TreatmentId = 1, TreatmentName = "Blodprøve", Description = "Blodprøver er blod udtaget fra en vene, som er de blodårer, der fører tilbage til hjertet. Blodet kan undersøges for sammensætning af salte, enzymer og proteiner, og i et vist omfang genetisk materiale. " }
			   );
		}

	}
}