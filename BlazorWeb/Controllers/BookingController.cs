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
		private readonly IAvailableRepository _availableRepo;
		public BookingController(IBookingRepository bookingRepo, IAvailableRepository availableRepo)
		{
			_bookingRepo = bookingRepo;
			_availableRepo = availableRepo;
		}

		[HttpGet("{id}")]
		public async Task<ICollection<Booking>> GetBookingsByPatientId(int Id)
		{
			return await _bookingRepo.GetBookingsByPatientId(Id);
		}

		[HttpGet]
		public async Task<ICollection<Available>> GetAllAvailable()
		{
			return  _availableRepo.GetAllAvailables().ToList();
		}

		[HttpPost]
		public async Task CreateBooking(Booking booking)
		{
			Available available = await _availableRepo.GetAvailableById(booking.AvailableId);
			if (available.IsTaken == false)
			{
				await _bookingRepo.CreateBooking(booking);
			}
		}


		[HttpPut]
		public async Task UpdateBooking(Booking booking)
		{
			Available available = await _availableRepo.GetAvailableById(booking.AvailableId);
			if (available.IsTaken == false)
			{
				await _bookingRepo.UpdateBooking(booking);
			}
		}

		[HttpDelete("{id}")]
		public async Task DeleteBooking(int Id)
		{
			await _bookingRepo.DeleteBooking(Id);
		}
	}
}
