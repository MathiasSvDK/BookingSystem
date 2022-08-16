using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer.Entities
{
	public class Booking
	{
		public int BookingId { get; set; }
		public string Reason { get; set; }

		public int TreatmentId { get; set; }
		public Treatment? Treatment { get; set; }

		public int AvailableId { get; set; }
		public Available? Available { get; set; }

		public int PatientId { get; set; }
		public int HospitalId { get; set; }


	}
}
