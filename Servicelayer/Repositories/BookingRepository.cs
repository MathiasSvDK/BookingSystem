using Datalayer;
using Datalayer.Entities;
using Microsoft.EntityFrameworkCore;
using Servicelayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicelayer.Repositories
{
	public class BookingRepository : IBookingRepository
	{
		private readonly BookingContext _bookingContext;
		public BookingRepository(BookingContext bookingContext)
		{
			_bookingContext = bookingContext;
		}

		public async Task<ICollection<Booking>> GetBookingsByPatientId(int patientId)
		{
			return await _bookingContext.Bookings.Include(t => t.Treatment).Include(a => a.Available).Where(p => p.PatientId == patientId).ToListAsync();
		}

		public async Task<ICollection<Booking>> GetBookingByBookingId(int bookingId)
		{
			return await _bookingContext.Bookings.Include(t => t.Treatment).Include(a => a.Available).Where(b => b.BookingId == bookingId).ToListAsync();
		}

		public async Task<ICollection<Booking>> GetAllBookings()
		{
			int year = DateTime.UtcNow.Year;
			return await _bookingContext.Bookings.Include(t => t.Treatment).Include(a => a.Available).Where(d => d.Available.Date.Year == year).ToListAsync();
		}

		public async Task CreateBooking(Booking booking)
		{
			_bookingContext.Bookings.Add(booking);
			await _bookingContext.SaveChangesAsync();
		}

		public async Task UpdateBooking(Booking booking)
		{
			_bookingContext.Bookings.Update(booking);
			await _bookingContext.SaveChangesAsync();
		}

		public async Task DeleteBooking(int bookingId)
		{
			Booking booking = await _bookingContext.Bookings.Where(b => b.BookingId == bookingId).FirstOrDefaultAsync();
			_bookingContext.Bookings.Remove(booking);
			await _bookingContext.SaveChangesAsync();
		}

	}
}
