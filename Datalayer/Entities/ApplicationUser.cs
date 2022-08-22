using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer.Entities
{
	public class ApplicationUser : IdentityUser
	{
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public string Mobilnr { get; set; }
		public int Role { get; set; }
		public int HospitalId { get; set; }
		public string Email { get; set; }
		public string Note { get; set; }
		public string? Address { get; set; }
	}
}
