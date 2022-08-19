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
		public bool IsDischarge { get; set; } = false;
		public int PatientId { get; set; }
		public int HospitalId { get; set; }
	}
}
