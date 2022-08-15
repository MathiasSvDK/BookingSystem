using Datalayer.Entities;

namespace Servicelayer.Interfaces
{
	public interface IBookingRepository
	{
		Task CreateBooking(Booking booking);
		Task DeleteBooking(int bookingId);
		Task<ICollection<Booking>> GetAllBookings();
		Task<ICollection<Booking>> GetBookingByBookingId(int bookingId);
		Task<ICollection<Booking>> GetBookingsByPatientId(int patientId);
		Task UpdateBooking(Booking booking);
	}
}