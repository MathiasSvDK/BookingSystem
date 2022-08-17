using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer.Entities
{
	public class Treatment
	{
		public int TreatmentId { get; set; }
		public string TreatmentName { get; set; }
		public string Description { get; set; }

		public ICollection<Booking>? Bookings { get; set; }
	}
}
