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

	}
}