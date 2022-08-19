using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer.Entities
{
	public class Hospitalization
	{
		public int HospitalizationID { get; set; }
		public string Reason { get; set; }
		public DateTime TimeOfHospitalized { get; set; }
		public DateTime TimeOfDischarged { get; set; }
		public bool IsDischarged { get; set; } = false;
		public int PatientId { get; set; }
		public int HospitalId { get; set; }
	}
}
