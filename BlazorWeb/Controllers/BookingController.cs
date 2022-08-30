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
		private readonly ITreatmentRepository _treatmentRepo;
		public BookingController(IBookingRepository bookingRepo, IAvailableRepository availableRepo, ITreatmentRepository treatmentRepo)
		{
			_bookingRepo = bookingRepo;
			_availableRepo = availableRepo;
			_treatmentRepo = treatmentRepo;
		}

		[Route("patient/{id}")]
		[HttpGet]
		public async Task<ICollection<Booking>> GetBookingsByPatientId(string Id)
		{
			return _bookingRepo.GetBookingsByPatientId(Id).ToList();
		}


		[HttpGet("{id}")]
		public async Task<Booking> GetBookingByBookingId(int Id)
		{
			return await _bookingRepo.GetBookingByBookingId(Id);
		}

		[HttpGet]
		public async Task<ICollection<Booking>> GetAllBookings()
		{
			return _bookingRepo.GetAllBookings().ToList();
		}

		[Route("available")]
		[HttpGet]
		public async Task<ICollection<Available>> GetAllAvailables()
		{
			return _availableRepo.GetAllAvailables().ToList();
		}

		[Route("availablenottaken")]
		[HttpGet]
		public async Task<ICollection<Available>> GetAllAvailablesNotTaken()
		{
			return _availableRepo.GetAllAvailablesNotTaken().ToList();
		}

		[Route("treatment")]
		[HttpGet]
		public async Task<ICollection<Treatment>> GetAllTreatments()
		{
			return _treatmentRepo.GetAllTreatments().ToList();
		}

		[HttpPost]
		public async Task CreateBooking(Booking booking)
		{
			Available available = await _availableRepo.GetAvailableById(booking.AvailableId);
			if (available.IsTaken == false)
			{
				available.IsTaken = true;
				await _availableRepo.UpdateAvailable(available);
				await _bookingRepo.CreateBooking(booking);
			}
		}


		[HttpPut]
		public async Task UpdateBooking(Booking booking)
		{
			await _bookingRepo.UpdateBookingForApi(booking);
		}

		[HttpDelete("{id}")]
		public async Task DeleteBooking(int Id)
		{
			await _bookingRepo.DeleteBooking(Id);
		}
	}
}
