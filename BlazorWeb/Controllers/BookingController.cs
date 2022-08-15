using Datalayer;
using Datalayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicelayer.Interfaces;

namespace BlazorWeb.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookingController : ControllerBase
	{
		private readonly IBookingRepository _bookingRepo;
		public BookingController(IBookingRepository bookingRepo)
		{
			_bookingRepo = bookingRepo;
		}

		[HttpGet("{id}")]
		public async Task<ICollection<Booking>> GetBookingsByPatientId(int Id)
		{
			return await _bookingRepo.GetBookingsByPatientId(Id);
		}

		[HttpPost]
		public async Task CreateBooking(Booking booking)
		{
			await _bookingRepo.CreateBooking(booking);
		}

		[HttpPut]
		public async Task UpdateBooking(Booking booking)
		{
			await _bookingRepo.UpdateBooking(booking);
		}

		[HttpDelete("{id}")]
		public async Task DeleteBooking(int Id)
		{
			await _bookingRepo.DeleteBooking(Id);
		}
	}
}
