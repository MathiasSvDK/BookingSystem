using Datalayer.Entities;

namespace Servicelayer.Interfaces
{
	public interface IBookingRepository
	{
		/// <summary>
		/// Creates a booking of an outpatient examination
		/// </summary>
		/// <param name="booking"></param>
		/// <returns></returns>
		Task CreateBooking(Booking booking);
		/// <summary>
		/// Deletes a booking of an outpatient examination
		/// </summary>
		/// <param name="bookingId"></param>
		/// <returns></returns>
		Task DeleteBooking(int bookingId);
		/// <summary>
		/// Gets all bookings of an outpatient examination
		/// </summary>
		/// <returns></returns>
		IQueryable<Booking> GetAllBookings();
		/// <summary>
		/// Get a booking of an outpatient examination by the bookingId
		/// </summary>
		/// <param name="bookingId"></param>
		/// <returns></returns>
		Task<Booking> GetBookingByBookingId(int bookingId);
		/// <summary>
		/// Get a booking of an outpatient examination by the patientId
		/// </summary>
		/// <param name="patientId"></param>
		/// <returns></returns>
		IQueryable<Booking> GetBookingsByPatientId(string patientId);
		/// <summary>
		/// Updates the booking of an outpatient examination
		/// </summary>
		/// <param name="booking"></param>
		/// <returns></returns>
		Task UpdateBooking(Booking booking);
		/// <summary>
		/// Updates the booking of an outpatient examination for the Api
		/// </summary>
		/// <param name="booking"></param>
		/// <returns></returns>
		Task UpdateBookingForApi(Booking booking);
		/// <summary>
		/// Sends a mail
		/// </summary>
		/// <param name="email"></param>
		/// <param name="subject"></param>
		/// <param name="plainTextContent"></param>
		/// <param name="htmlMessage"></param>
		/// <returns></returns>
		Task SendEmailAsync(string email, string subject, string plainTextContent, string htmlMessage);
	}
}