using Datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicelayer.Repositories
{
	public class HospitalizationRepository
	{
		private readonly BookingContext _bookingContext;
		public HospitalizationRepository(BookingContext bookingContext)
		{
			_bookingContext = bookingContext;
		}

	}
}
