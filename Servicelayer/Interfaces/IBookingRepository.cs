using Datalayer.Entities;

namespace Servicelayer.Interfaces
{
	public interface IBookingRepository
	{
		Task CreateBooking(Booking booking);
		Task DeleteBooking(int bookingId);
		IQueryable<Booking> GetAllBookings();
		Task<Booking> GetBookingByBookingId(int bookingId);
		IQueryable<Booking> GetBookingsByPatientId(int patientId);
		Task UpdateBooking(Booking booking);
	}
}