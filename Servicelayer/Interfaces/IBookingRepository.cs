using Datalayer.Entities;

namespace Servicelayer.Interfaces
{
	public interface IBookingRepository
	{
		Task CreateBooking(Booking booking);
		Task DeleteBooking(int bookingId);
		IQueryable<Booking> GetAllBookings();
		Task<Booking> GetBookingByBookingId(int bookingId);
		IQueryable<Booking> GetBookingsByPatientId(string patientId);
		Task UpdateBooking(Booking booking);
		Task UpdateBookingForApi(Booking booking);
		Task SendEmailAsync(string email, string subject, string plainTextContent, string htmlMessage);
	}
}