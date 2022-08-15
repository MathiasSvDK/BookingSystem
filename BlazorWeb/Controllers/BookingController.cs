using Datalayer;
using Datalayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWeb.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookingController : ControllerBase
	{
		private readonly BookingContext _bookingContext;
		public BookingController(BookingContext bookingContext)
		{
			_bookingContext = bookingContext;
		}

		[HttpGet]
		public async Task<ActionResult<ICollection<Booking>>> GetBookingsByPatientId(int patientId)
		{
			return null;
		}
	}
}
