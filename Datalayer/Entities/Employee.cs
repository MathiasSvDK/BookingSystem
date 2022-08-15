using System;
using System.Collections.Generic;

namespace Datalayer.Entities
{
	public partial class Employee
	{
		public int Id { get; set; }
		public string? Firstname { get; set; }
		public string? Lastname { get; set; }
		public string? Mobilnr { get; set; }
		public int? Role { get; set; }
		public int? HospitalId { get; set; }
		public string? Email { get; set; }
	}
}
